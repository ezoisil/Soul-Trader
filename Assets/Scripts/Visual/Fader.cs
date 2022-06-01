using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Visual
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] Color startColor;
        [SerializeField] Color endColor;
        [Range(0, 50)][SerializeField] float fadeDuration;

        private float fadeAmount = 0;


        void Start()
        {
            
        }

        void FixedUpdate()
        {
            ColourChanging();
        }

        void ColourChanging()
        {             
                gameObject.GetComponent<Renderer>().material.color =  Color.Lerp(startColor, endColor, fadeAmount);
                if (fadeAmount <= 1)
                {
                    fadeAmount += Time.deltaTime / fadeDuration;
                }
            

        }
    }

}