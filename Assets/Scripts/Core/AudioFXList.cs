using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "AudioFXList", menuName = "Audio/fxList", order = 0)]
    public class AudioFXList : ScriptableObject
    {
        public SFXType sfxType;
        [SerializeField] public AudioClip[] clips;
    }
}