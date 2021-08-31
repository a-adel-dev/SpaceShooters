
using UnityEngine;


namespace Core
{
    public class SfxAudioPlayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audio;
        [SerializeField] AudioFXList fxList;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        public void PlayAudio()
        {
            _audio.PlayOneShot(fxList.clips[0], AudioSettings.SfxVolume);
        }
    }

    public interface IAudioPlayer
    {
        void PlayAudio();
    }
}