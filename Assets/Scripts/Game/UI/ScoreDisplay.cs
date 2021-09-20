using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = $"00000000";
        }

        public void UpdateScore(int score)
        {
            GetComponent<TextMeshProUGUI>().text = $"{score:D8}";
        }
    }

}