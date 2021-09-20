using Core;
using UnityEngine;

namespace Game.Data
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData bulletData;
        private bool _activated;
        private float _bulletSpeed;
        private float _bulletLife;
        

        private void Update()
        {
            MoveBullet();
            if (_bulletLife>=bulletData.bulletLife)
            {
                gameObject.SetActive(false);
            }
            _bulletLife += Time.deltaTime;
        }

        private void MoveBullet()
        {
            if (_activated is false) return; 
            transform.position += transform.TransformDirection(Vector3.up) * (_bulletSpeed * Time.deltaTime);
        }

        public void Activate()
        {
            _bulletSpeed = bulletData.bulletSpeed;
            _activated = true;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _bulletLife = 0;
            _activated = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<IDamageable>().Damage();
                Deactivate();
                GameEvents.EnemyDestroyed(other.GetComponent<Enemy>().ScoreValue);
            }
        }
    }
    
}