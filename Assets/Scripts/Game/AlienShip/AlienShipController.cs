using System;
using Core;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Game.AlienShip
{
    public class AlienShipController : MonoBehaviour, IDamageable
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] int maxWayPoints;
        private bool _foundPosition;
        private int _wayPointCounter;

        private Vector3 _currentWayPoint;
        private VFXPlayer _fxPlayer;
        private SfxAudioPlayer _sfxPlayer;

        private void Awake()
        {
            _fxPlayer = GetComponent<VFXPlayer>();
            _sfxPlayer = GetComponent<SfxAudioPlayer>();
        }

        void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_wayPointCounter > maxWayPoints)
            {
                transform.position += (Vector3.left) * (movementSpeed * Time.deltaTime);
                if (transform.position.x < ScreenUtils.ScreenLeft - 2)
                {
                    Destroy(gameObject);
                }

                return;
            }

            if (_foundPosition)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _currentWayPoint, movementSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, _currentWayPoint) <= 1f)
                {
                    _foundPosition = false;
                }

                return;
            }

            float randomXPos = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
            float randomYPos = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);

            _currentWayPoint = new Vector3(randomXPos, randomYPos, 0);
            _wayPointCounter++;
            _foundPosition = true;
        }

        public void Damage()
        {
            _sfxPlayer.PlayAudio(SFXType.Explosion);
            _fxPlayer.PlayExplosionFX();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                return;
            }
            if (other.CompareTag("Player"))
            {
                other.GetComponent<IDamageable>().Damage();
                Damage();
            }
        }
    }
}