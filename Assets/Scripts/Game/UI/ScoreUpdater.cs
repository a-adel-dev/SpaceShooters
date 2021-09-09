using Core;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class ScoreUpdater : MonoBehaviour
    {
        private int _score;

        public int Score { get => _score; set => _score = value; }
        
        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = $"{Score:D8}";
            GameEvents.onEnemyDestroyed += ONEnemyDestroyed;
        }

        private void ONEnemyDestroyed(int score)
        {
            Score += score;
            GetComponent<TextMeshProUGUI>().text = $"{Score:D8}";
        }

    }

}