using System.Collections;
using Core;
using Game.UI;
using JetBrains.Annotations;
using UnityEngine;
using Utils;

namespace Game.Data
{
    public class HighScoreController : MonoBehaviour
    {
        [SerializeField] private HighScoreDisplay highScoreDisplay;
        [CanBeNull] private string _name;
        private SaveData sd;
        private ScoreRecorder scoreRecorder;

        private void Start()
        {
            sd = new SaveData();
            LoadJsonFile();
            scoreRecorder = GetComponent<ScoreRecorder>();
        }
        
        //event on game over
        public void StartGameOverEvents()
        {
            StartCoroutine(DisplayPlayerNameInputDialogue());
        }

        IEnumerator DisplayPlayerNameInputDialogue()
        {
            yield return highScoreDisplay.DisplayGameOverPanel();
            if (IsHighScore())
            {
                highScoreDisplay.GetCurrentPlayerInfo();
            }
            else
            {
                highScoreDisplay.DisplayHighScoreList(sd);
            }
        }

        private bool IsHighScore()
        {
            if (sd==null)
            {
                Debug.LogError("SaveData was not loaded");
            }
            return sd != null && sd.IsHighScore(scoreRecorder.Score);
        }

        private void LoadJsonFile()
        {
            if (FileManager.IsSaveFileExist("scores.dat"))
            {
                if (FileManager.LoadFromFile("scores.dat", out var json))
                {
                    sd.LoadFromJson(json);
                    //Debug.Log($"Load complete, list contains {sd.highScoresList.Count} entries");
                }
            }
            else
            {
                SaveJsonData();
            }
        }
        
        //event on player submitting their name
        public void UpdateHighScoreList(string playerName)
        {
            _name = playerName;
            SaveJsonData();
            highScoreDisplay.DisplayHighScoreList(sd);
        }
        
        void SaveJsonData()
        {   
            PopulateSaveData();
            
            if (FileManager.WriteToFile("scores.dat", sd.ToJson()))
            {
                Debug.Log("Save successful");
            }
        }

        public void PopulateSaveData()
        {
            if (_name == null)
            {
                Debug.Log("name was null");
                return;
            }
            sd.AddScorePairToList(_name, scoreRecorder.Score);
        }
        
    }
    
    
}