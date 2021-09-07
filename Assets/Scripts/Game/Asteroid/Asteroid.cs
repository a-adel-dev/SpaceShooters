using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Asteroid
{
    public class Asteroid : MonoBehaviour, IDamageable
    {
        private float _asteroidLife;
        public AsteroidSize AsteroidSize { get; set; }
        private AsteroidVFXPlayer _asteroidVFX;
        private SfxAudioPlayer _sfxPlayer;


        private void Start()
        {
            _asteroidVFX = GetComponent<AsteroidVFXPlayer>();
            _sfxPlayer = GetComponent<SfxAudioPlayer>();
        }

        private void Update()
        {
            _asteroidLife += Time.deltaTime;
        }

        public void SetAsteroidSize()
        {
            if (AsteroidSize == AsteroidSize.Medium)
            {
                transform.localScale *= 0.5f;
                return;
            }

            if (GetComponent<Asteroid>().AsteroidSize == AsteroidSize.Small)
            {
                transform.localScale *= 0.25f;
            }
        }

        public void Damage()
        {
            if (GetComponent<AsteroidMover>().ScreenBound is false)
            {
                return;
            }
            switch (AsteroidSize)
            {
                case AsteroidSize.Big:
                    _sfxPlayer.PlayAudio();
                    SpawnAsteroids( AsteroidSize.Medium, 2);
                    _asteroidVFX.PlayExplosionFX();
                    AsteroidPool.Add(gameObject);
                    break;
                case AsteroidSize.Medium:
                    _sfxPlayer.PlayAudio();
                    SpawnAsteroids( AsteroidSize.Small, 2);
                    _asteroidVFX.PlayExplosionFX();
                    AsteroidPool.Add(gameObject);
                    break;
                case AsteroidSize.Small:
                    _sfxPlayer.PlayAudio();
                    _asteroidVFX.PlayExplosionFX();
                    AsteroidPool.Add(gameObject);
                    break;
            }
        }
        
        private void SpawnAsteroids(AsteroidSize size, int numberOfAsteroids)
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                GameObject asteroid = AsteroidPool.Get();
                asteroid.transform.position = transform.position;
                Vector3 direction = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0);
                asteroid.GetComponent<AsteroidMover>().Push(direction);

                asteroid.GetComponent<Asteroid>().AsteroidSize = size;
                asteroid.GetComponent<Asteroid>().SetAsteroidSize();
                asteroid.GetComponent<AsteroidMover>().SetAsteroidSpeed();
                asteroid.GetComponent<AsteroidMover>().Activate();

                SpriteRenderer asteroidSpriteRenderer = asteroid.transform.GetChild(0).GetComponent<SpriteRenderer>();
                asteroidSpriteRenderer.sortingOrder = 2;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_asteroidLife < 1f || other.CompareTag("Enemy"))
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