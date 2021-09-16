
using UnityEngine;


namespace Core
{
    public class SfxAudioPlayer : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audio;
        [SerializeField] private AudioFXList[] fxList;

        private void Awake()
        {
            if (Camera.main is { }) _audio = Camera.main.GetComponent<AudioSource>();
        }
        
        public void PlayAudio(SFXType type)
        {
            foreach (AudioFXList sfx in fxList)
            {
                if (sfx.sfxType != type) continue;
                int randomIndex = Random.Range(0, sfx.clips.Length);
                _audio.PlayOneShot(sfx.clips[randomIndex], AudioSettings.SfxVolume);
            }
        }

        public void PlayEffect(int fxTypeIndex)
        {
            PlayAudio((SFXType)fxTypeIndex);
        }
    }

    public interface IAudioPlayer
    {
        void PlayAudio(SFXType type);
    }
}