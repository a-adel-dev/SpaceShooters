﻿using System;
using UnityEngine;


namespace Core
{
    public class MusicPlayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audio;
        [SerializeField] AudioFXList fxList;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayAudio();
        }

        private void Update()
        {
            if (_audio.isPlaying is false)
            {
                PlayAudio();
            }
        }

        public void PlayAudio()
        {
            _audio.PlayOneShot(fxList.clips[0], AudioSettings.MusicVolume);
        }
    }
}