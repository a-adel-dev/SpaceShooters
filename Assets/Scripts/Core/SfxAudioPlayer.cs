
using UnityEngine;


namespace Core
{
    public class SfxAudioPlayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audio;
        [SerializeField] AudioFXList fxList;

        private void Awake()
        {
            _audio = Camera.main.GetComponent<AudioSource>();
        }

        public void PlayAudio()
        {
            int randomIndex = Random.Range(0, fxList.clips.Length);
            _audio.PlayOneShot(fxList.clips[randomIndex], AudioSettings.SfxVolume);
        }
    }

    public interface IAudioPlayer
    {
        void PlayAudio();
    }
}