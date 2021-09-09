using System;
using Core;
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
    }
}