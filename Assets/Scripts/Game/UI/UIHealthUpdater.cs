using System;
using Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIHealthUpdater : MonoBehaviour
    {
        [SerializeField] Image bloodImage;
        private void Start()
        {
            GameEvents.onPlayerHealthChanged += UpdateHealthVisualInfo;
        }
        
        void UpdateHealthVisualInfo(float value)
        {
            GetComponent<Slider>().value = value;
            float modifiedValue = (float)(Math.Pow(Math.E, (-10f * value)));
            Color bloodImageValue = new Color(modifiedValue,  modifiedValue, modifiedValue, 1f);
            bloodImage.color = bloodImageValue;
        }

        public void ResetUI()
        {
            GetComponent<Slider>().value = 1f;
            bloodImage.color = new Color(0f, 0f, 0f, 1f);
            //Debug.Log($"Resetting health stuff");
        }

        private void OnDestroy()
        {
            GameEvents.onPlayerHealthChanged -= UpdateHealthVisualInfo;
        }
    }
}