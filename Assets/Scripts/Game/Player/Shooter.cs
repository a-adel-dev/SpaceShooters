using Core;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class Shooter : MonoBehaviour
    {
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
                GameObject projectileObject =
                    ObjectPooler.Instance.SpawnFromPool(PoolTypes.PlayerProjectile, transform.position, quaternion.identity);
                projectileObject.transform.localEulerAngles = transform.localEulerAngles;
                projectileObject.GetComponent<Projectile>().Activate();
                _timeSinceLastShot = 0;

                PlayShootingSFX(projectileObject);

            }
        }

        private void PlayShootingSFX(GameObject projectileObject)
        {
            GetComponent<SfxAudioPlayer>().PlayAudio(SFXType.Bullet);
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