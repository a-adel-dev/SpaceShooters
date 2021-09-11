using UnityEngine;

namespace Game.UI
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private GameObject creditsCanvas;

        public void ToggleUICanvas()
        {
            uiCanvas.SetActive(!uiCanvas.activeSelf);
            creditsCanvas.SetActive(!creditsCanvas.activeSelf);
        }
        
        
    }
}