using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jamination5.Visual;

namespace Jamination5.Audio
{
    public class RandomAudioPlayer : MonoBehaviour
    {
        [SerializeField] List<AudioClip> clips;
        private float duration=-2;

        private AudioSource audioSource;
        private bool isPlaying = false;

        [NonSerialized]public bool canPlay = false;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayText.onPlayText += PlayRandomAudio;
        }

        private void Update()
        {
            duration -= Time.deltaTime;
            if (duration < 0) return;
            
            StartCoroutine(playAudio());
        }

        private void PlayRandomAudio(float duration)
        {
            this.duration = duration;    
        }

        private IEnumerator playAudio()
        {
            if (isPlaying) yield break;
            isPlaying = true;
            audioSource.clip = clips[UnityEngine.Random.Range(0, clips.Count)];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length );
            isPlaying = false;
        }

        private void OnDestroy()
        {
            PlayText.onPlayText -= PlayRandomAudio;
        }
    }
    
}