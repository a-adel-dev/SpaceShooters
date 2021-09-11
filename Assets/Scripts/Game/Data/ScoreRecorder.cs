using UnityEngine;
using UnityEngine.Events;

namespace Game.Data
{
    public class ScoreRecorder : MonoBehaviour
    {
        public int Score { get; private set; }
        [SerializeField] private UnityEvent<int> updateScore;

        private void Awake()
        {
            GameEvents.onEnemyDestroyed += UpdateScore;
        }

        public void ResetScore()
        {
            Score = 0;
        }
        
        private void UpdateScore(int score)
        {
            Score += score;
            updateScore?.Invoke(Score);
        }

        private void OnDestroy()
        {
            ResetScore();
            GameEvents.onEnemyDestroyed -= UpdateScore;
        }
    }
}