using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Core;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using Utils;

namespace Game.UI
{
    public class HighScoreManager : MonoBehaviour
    {
        [SerializeField] GameObject PlayerNameInputDialogue;
        [FormerlySerializedAs("GameOverpanel")] [SerializeField] private GameObject GameOverpanelUI;
        [FormerlySerializedAs("HighScoreList")] [SerializeField] private GameObject HighScoreListUI;
        private string _name;
        private int _highscore;
        [SerializeField] private ScoreUpdater scoreUpdater;
        private SaveData sd;

        private void Start()
        {
            sd = new SaveData();
        }

        public void onGameOver()
        {
            StartCoroutine(DisplayPlayerNameInputDialogue());
        }

        IEnumerator DisplayGameOverPanel()
        {
            GameOverpanelUI.SetActive(true);
            yield return new WaitForSeconds(4f);
            GameOverpanelUI.SetActive(false);
        }

        private InputField GetInputField(GameObject playerNameInputDialogue)
        {
            foreach (Transform child in playerNameInputDialogue.transform)
            {
                if (child.GetComponent<InputField>()) return child.GetComponent<InputField>();
            }
            return null;
        }

        IEnumerator DisplayPlayerNameInputDialogue()
        {
            yield return DisplayGameOverPanel();
            if (isHighScore())
            {
                GetCurrentPlayerInfo();
            }
            else
            {
                DisplayHighScoreList();
            }
        }

        private bool isHighScore()
        {
            LoadJsonFile();
            return sd.IsHighScore(scoreUpdater.Score);
        }

        private void LoadJsonFile()
        {
            if (FileManager.LoadFromFile("scores.dat", out var json))
            {
                sd.LoadFromJson(json);
                Debug.Log($"Load complete, list contains {sd.highScoresList.Count} entries");
            }
        }

        private void GetCurrentPlayerInfo()
        {
            PlayerNameInputDialogue.SetActive(true);
            InputField input = GetInputField(PlayerNameInputDialogue);
            input?.Select();
            input?.ActivateInputField();
        }

        public void UpdateHighScoreList(string name)
        {
            PlayerNameInputDialogue.SetActive(false);
            _name = name;
            _highscore = scoreUpdater.Score;
            SaveJsonData();
            DisplayHighScoreList();
        }

        private void DisplayHighScoreList()
        {
            HighScoreListUI.GetComponent<HighScoreDisplay>().DisplayHighScore(sd.highScoresList);
            HighScoreListUI.SetActive(true);
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
            sd.AddScorePairToList(_name, _highscore);
        }
        
    }
    
    
}