using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class TransitionScene : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1);
        }
    }
}