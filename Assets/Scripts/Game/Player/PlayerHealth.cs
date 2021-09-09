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
        [SerializeField] private UnityEvent gameOver;
        private VFXPlayer _fxVFXPlayer;
        private SfxAudioPlayer _sfxPlayer;

        private void Awake()
        {
            currentHealth = baseHealth;
            _fxVFXPlayer = GetComponent<VFXPlayer>();
            _sfxPlayer = GetComponent<SfxAudioPlayer>();
        }


        public void Damage()
        {
            currentHealth -= damageValue;
            GameEvents.PlayerHealthChanged((float)currentHealth / baseHealth);
            _fxVFXPlayer.PlayHitFX();
            hitShaker?.Invoke();
            if (currentHealth <= 0)
            {
                deathShaker.Invoke();
                _sfxPlayer.PlayAudio();
                _fxVFXPlayer.PlayExplosionFX();
                currentHealth = 0;
                gameOver?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}