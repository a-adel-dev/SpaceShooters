using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class SaveData
    {
        public List<ScorePair> highScoresList = new List<ScorePair>();
        public int MaxHighScoreItems { get; set; } = 8;
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string a_Json)
        {
            JsonUtility.FromJsonOverwrite(a_Json, this);
        }

        public void AddScorePairToList(string name, int highScore)
        {
            ScorePair pair = new ScorePair(name, highScore);
            highScoresList.Add(pair);
            highScoresList.Sort();
            highScoresList.Reverse();
            CleanHighScoreList();
        }

        private void CleanHighScoreList()
        {
            if (highScoresList.Count > MaxHighScoreItems)
            {
                highScoresList.RemoveAt(MaxHighScoreItems);
            }
        }

        public bool IsHighScore(int score)
        {
            return  highScoresList.Count < MaxHighScoreItems || score > highScoresList[MaxHighScoreItems-1].score;
        }
    }
    
    [Serializable]
    public struct ScorePair : IComparable<ScorePair>
    {

        public string name;
        public int score;
        

        public ScorePair(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(ScorePair other)
        {
            return score.CompareTo(other.score);
        }
    }

    
}