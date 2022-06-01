using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

namespace Jamination5.Visual
{
    public class PlayText : MonoBehaviour
    {
        [TextArea][SerializeField] List<string> texts;
        [Range(1, 10)][SerializeField] float speakDuration;
        [SerializeField] float startIn;
        private TextMeshProUGUI textTMP;
        //private List<string> initilizedTexts;
        public delegate void OnPlayText(float duration);
        public delegate void OnEndText();
        public static event OnPlayText onPlayText;
        public static event OnEndText onEndText;

        private void Awake()
        {
            textTMP = GetComponentInChildren<TextMeshProUGUI>();
            //initilizedTexts = texts;
        }
        IEnumerator Start()
        {
            yield return new WaitForSeconds(startIn);
            yield return StartCoroutine(DisplayText());
        }
        
        IEnumerator DisplayText()
        {
            int i = texts.Count;
            foreach (string text in texts)
            {
                i--;
                textTMP.text = text;
                onPlayText.Invoke(Mathf.Lerp(.08f,1.8f, text.Length) );
                if(i == 0)
                {
                    onEndText.Invoke();

                }
                yield return new WaitForSeconds(speakDuration);
                
            }

        }
    }
}
