using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Jamination5.Visual
{
    public class PlayText : MonoBehaviour
    {
        [TextArea][SerializeField] List<string> texts;
        [SerializeField] float startIn;
        [Range(0,5)][SerializeField] float minSpeakTime = .4f;
        [Range(0, 5)][SerializeField] float maxSpeakTime= 2.8f;


        private TextMeshProUGUI textTMP;
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
                onPlayText.Invoke(SpeakDurationCalculator(text)); // BURAYA BAK!!!
                if(i == 0)
                {
                    onEndText.Invoke();

                }
                yield return new WaitForSeconds(SpeakDurationCalculator(text) +1);
                
            }

        }

        private float SpeakDurationCalculator(string text)
        {
            float speakDuration;
            float fraction;

            fraction = Mathf.InverseLerp(0, 70, text.Length);
            
            speakDuration = Mathf.Lerp(minSpeakTime,maxSpeakTime, fraction);
            print(speakDuration);
            print(text.Length * 0.05f);

            return speakDuration;
        }
    }
}
