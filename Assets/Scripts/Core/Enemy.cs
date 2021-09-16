using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class Enemy : MonoBehaviour
    {
        [FormerlySerializedAs("_scoreValue")] [SerializeField] private int scoreValue;

        public int ScoreValue
        {
            get => scoreValue;
            set => scoreValue = value;
        }
    }
}