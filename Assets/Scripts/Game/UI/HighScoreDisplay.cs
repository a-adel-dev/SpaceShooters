using System.Collections;
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
            _names.GetComponent<TextMeshProUGUI>().text = "";
            _scores.GetComponent<TextMeshProUGUI>().text  = "";
            for (int i = 0; i < Mathf.Min(highScoreList.Count,8); i++)
            {
                _names.GetComponent<TextMeshProUGUI>().text += highScoreList[i].name + "\n";
                _scores.GetComponent<TextMeshProUGUI>().text += highScoreList[i].score + "\n";
            }
        }
        
        public IEnumerator DisplayGameOverPanel()
        {
            transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        
        public void GetCurrentPlayerInfo()
        {
            transform.GetChild(1).gameObject.SetActive(true);
            TMP_InputField input = GetInputField(transform.GetChild(1).gameObject);
            input.Select();
            input.ActivateInputField();
        }
        
        private TMP_InputField GetInputField(GameObject playerNameInputDialogue)
        {
            foreach (Transform child in playerNameInputDialogue.transform)
            {
                if (child.GetComponent<TMP_InputField>()) return child.GetComponent<TMP_InputField>();
            }
            return null;
        }
        
        public void DisplayHighScoreList(SaveData sd)
        {
            DisplayHighScore(sd.highScoresList);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
        //event on player submitting their name
        public void DisablePlayerNameWindow()
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}