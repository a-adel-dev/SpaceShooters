using Core;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class ScoreUpdater : MonoBehaviour
    {

        private int _score;
        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = $"{_score:D8}";
            GameEvents.onEnemyDestroyed += ONEnemyDestroyed;
        }

        private void ONEnemyDestroyed(int score)
        {
            _score += score;
            GetComponent<TextMeshProUGUI>().text = $"{_score:D8}";
        }

    }

}