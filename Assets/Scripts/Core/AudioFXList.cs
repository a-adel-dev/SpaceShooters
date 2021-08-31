using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "AudioFXList", menuName = "Audio/fxList", order = 0)]
    public class AudioFXList : ScriptableObject
    {
        [SerializeField] public AudioClip[] clips;
    }
}