using Core;
using UnityEngine;

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
            Enemy enemy = GetComponent<Enemy>();
            enemy.ScoreValue = 12;
            
            if (AsteroidSize == AsteroidSize.Medium)
            {
                transform.localScale *= 0.5f;
                enemy.ScoreValue = 20;
                return;
            }

            if (GetComponent<Asteroid>().AsteroidSize == AsteroidSize.Small)
            {
                enemy.ScoreValue = 33;
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
                    _sfxPlayer.PlayAudio(SFXType.Explosion);
                    DestroyAsteroid( AsteroidSize.Medium, 2);
                    _asteroidVFX.PlayExplosionFX();
                    ResetAsteroid();
                    gameObject.SetActive(false);
                    break;
                case AsteroidSize.Medium:
                    _sfxPlayer.PlayAudio(SFXType.Explosion);
                    DestroyAsteroid( AsteroidSize.Small, 2);
                    _asteroidVFX.PlayExplosionFX();
                    ResetAsteroid();
                    gameObject.SetActive(false);
                    break;
                case AsteroidSize.Small:
                    _sfxPlayer.PlayAudio(SFXType.Explosion);
                    _asteroidVFX.PlayExplosionFX();
                    ResetAsteroid();
                    gameObject.SetActive(false);
                    break;
            }
        }

        private void DestroyAsteroid(AsteroidSize size, int numAsteroids)
        {
            for (int i = 0; i < numAsteroids; i++)
            {
                GameObject asteroid = ObjectPooler.Instance.SpawnFromPool(PoolTypes.Asteroids, transform.position,
                    Quaternion.identity);
                float randomX = Random.Range(0, 1f);
                float randomY = Random.Range(0, 1f);
                asteroid.GetComponent<AsteroidMover>().Push(new Vector3(randomX,randomY,0));
            
                float randomRotation = Random.Range(0, 359f);
                asteroid.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, randomRotation);

                asteroid.GetComponent<Asteroid>().AsteroidSize = size;
                asteroid.GetComponent<Asteroid>().SetAsteroidSize();
                asteroid.GetComponent<AsteroidMover>().SetAsteroidSpeed();
                asteroid.GetComponent<AsteroidMover>().Activate();


                int randomIndex = Random.Range(0, 999);
                SpriteRenderer asteroidSpriteRenderer = asteroid.transform.GetChild(0).GetComponent<SpriteRenderer>();
                asteroidSpriteRenderer.sortingOrder = randomIndex;
            }
        }

        private void ResetAsteroid()
        {
            gameObject.transform.localScale = Vector3.one;
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