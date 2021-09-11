using UnityEngine;

namespace Core
{
    public class SFXUIplayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audio;
        [SerializeField] AudioFXList fxList;


        private void Start()
        {
            _audio = Camera.main.GetComponent<AudioSource>();
        }

        public void PlayAudio()
        {
            throw new System.NotImplementedException();
        }

        public void PlayHoverSound()
        {
            _audio.PlayOneShot(fxList.clips[0], AudioSettings.SfxVolume);
        }

        public void PlayClickSound()
        {
            _audio.PlayOneShot(fxList.clips[1], AudioSettings.SfxVolume);
        }
    }
}