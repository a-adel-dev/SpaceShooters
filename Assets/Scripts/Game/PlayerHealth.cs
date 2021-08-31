using System;
using UnityEngine;

namespace Game
{
    public class PlayerHealth : MonoBehaviour , IDamageble
    {
        [SerializeField] private int baseHealth = 100;
        [SerializeField] private int currentHealth;
        [SerializeField] private int damageValue;

        private void Awake()
        {
            currentHealth = baseHealth;
        }


        public void Damage()
        {
            currentHealth -= damageValue;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
            }
        }
    }
}