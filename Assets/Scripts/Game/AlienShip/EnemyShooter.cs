using Core;
using UnityEngine;
using Utils;


namespace Game.AlienShip
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float firingCoolDown;
        [SerializeField] private float rotationSpeed = 0.05f;
        private float _timeSinceLastShot = float.MaxValue;
        private Bounds screenBounds;

        private void Start()
        {
            screenBounds = new Bounds(Camera.main.transform.position,
                new Vector3(ScreenUtils.ScreenRight * 2, ScreenUtils.ScreenTop * 2, Mathf.Infinity));
        }

        void Update()
        {
            _timeSinceLastShot += Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            Shoot();
        }
        
        private void Shoot()
        {
            if (screenBounds.Contains(transform.position) is false) return;
            if (CanFire())
            { 
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                _timeSinceLastShot = 0;
                
                PlayShootingSfx();
            }
        }

        private bool CanFire()
        {
            return _timeSinceLastShot >= firingCoolDown;
        }
        
        private void PlayShootingSfx()
        {
            transform.parent.GetComponent<SfxAudioPlayer>().PlayAudio(SFXType.Bullet);
        }
        
    }
}