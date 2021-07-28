using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float firingCoolDown;
        
        private float _timeSinceLastShot = float.MaxValue;
        private bool _shooting;


        private void Update()
        {
            _timeSinceLastShot += Time.deltaTime;
            Shoot();
        }

        public void Shoot()
        {
            if (Canfire())
            {
                GameObject projectileObject = PlayerProjectilePool.Get();
                projectileObject.transform.position = transform.position;
                projectileObject.transform.localEulerAngles = transform.localEulerAngles;
                projectileObject.GetComponent<Projectile>().Activate(bulletSpeed);
                _timeSinceLastShot = 0;
                Debug.Log("Bang!");
                
            }
        }

        private bool Canfire()
        {
            return _timeSinceLastShot > firingCoolDown && _shooting;
        }

        public void OnAttack(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                _shooting = ! _shooting;
            }

            if (!_shooting) _timeSinceLastShot = float.MaxValue;
        }
        
        
    }
}