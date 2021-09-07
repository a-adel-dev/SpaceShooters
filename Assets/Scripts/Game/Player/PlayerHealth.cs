using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Player
{
    public class PlayerHealth : MonoBehaviour , IDamageable
    {
        [SerializeField] private int baseHealth = 100;
        [SerializeField] private int currentHealth;
        [SerializeField] private int damageValue;
        [SerializeField] private UnityEvent hitShaker;
        [SerializeField] private UnityEvent deathShaker;
        public UnityAction<int> updateHealthUI;
        private PlayerVFX _fxPlayer;
        private SfxAudioPlayer _sfxPlayer;

        private void Awake()
        {
            currentHealth = baseHealth;
            _fxPlayer = GetComponent<PlayerVFX>();
            _sfxPlayer = GetComponent<SfxAudioPlayer>();
        }


        public void Damage()
        {
            currentHealth -= damageValue;
            _fxPlayer.PlayHitFX();
            hitShaker.Invoke();
            if (currentHealth <= 0)
            {
                deathShaker.Invoke();
                _sfxPlayer.PlayAudio();
                //fxPlayer.PlayExplosionFX();
                currentHealth = 0;
                Destroy(gameObject);
            }
        }
    }
}