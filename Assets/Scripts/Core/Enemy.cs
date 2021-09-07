using UnityEngine;

namespace Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _scoreValue;

        public int ScoreValue
        {
            get => _scoreValue;
        }
    }
}