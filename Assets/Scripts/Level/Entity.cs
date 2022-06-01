using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Level
{
    public class Entity : MonoBehaviour
    {
        [Range(0, 50)][SerializeField] float fadeDuration = 15f;
        [SerializeField] Color startColor = Color.white;
        [SerializeField] Color colorToFade = Color.black;
        [SerializeField] float fadeAmount = 0;
        private Emitter emitter = null;
        private float timer;


        private void Start()
        {
            timer = fadeDuration;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <0)
            {
                Attack();
            }
            ColourChanging();
        }
        private void Attack()
        {
            print("Attack");
            emitter.GetRootLevel().DropHealthPoints();
            Destroy(gameObject);
        }

        public void SetEmitter(Emitter emitter)
        {
            this.emitter = emitter;
        }

        void ColourChanging()
        {
            if (fadeAmount < fadeDuration)
            {

                fadeAmount += Time.deltaTime / fadeDuration; 
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(startColor, colorToFade,fadeAmount);              
               
            }

        } 
    }
    }

