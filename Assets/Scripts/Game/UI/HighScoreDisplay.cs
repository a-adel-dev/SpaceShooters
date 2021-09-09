using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Utils;

namespace Game.UI
{
    public class HighScoreDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _names;
        [SerializeField] private GameObject _scores;
        
        public void DisplayHighScore(List<ScorePair> highScoreList)
        {
            for (int i = 0; i < Mathf.Min(highScoreList.Count,8); i++)
            {
                _names.GetComponent<TextMeshProUGUI>().text += highScoreList[i].name + "\n";
                _scores.GetComponent<TextMeshProUGUI>().text += highScoreList[i].score + "\n";
            }
        }
    }
}