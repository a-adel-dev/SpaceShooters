using Core;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private int _spawnCoolDown;
        private int _waveCoolDown;
        private readonly Timer _spawnTimer = new Timer();
        private readonly Timer _waveTimer = new Timer();
        private bool _spawning = true;
        private bool _gameOver;
        

        private void Start()
        {
            SpawnObject();
            _spawnTimer.StartTimer(_spawnCoolDown);
            _waveTimer.StartTimer(_waveCoolDown);
        }

        public void SetSpawnValues(int spawnCd, int waveCd)
        {
            _spawnCoolDown = spawnCd;
            _waveCoolDown = waveCd;
        }

        private void SpawnObject()
        {
            if (_spawning)
            {
                int randomIndex = Random.Range(0, 3);
                AsteroidSize size = (AsteroidSize)randomIndex;
                SpawnAsteroids(size);
            }
        }

        public void SpawnAsteroids(AsteroidSize size)
        {
            GameObject asteroid = ObjectPooler.Instance.SpawnFromPool(PoolTypes.Asteroids, transform.position,
                    quaternion.identity);
            asteroid.GetComponent<AsteroidMover>().Push(transform.up);
            
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

        private void Update()
        {
            if (_gameOver is true)
            {
                _spawning = false;
                return;
            }
            _spawnTimer.Tick(Time.deltaTime);
            _waveTimer.Tick(Time.deltaTime);
            if (_spawnTimer.Finished)
            {
                SpawnObject();
                _spawnTimer.ResetTimer(_spawnCoolDown);
            }

            if (!_waveTimer.Finished) return;
            _waveTimer.ResetTimer(_waveCoolDown);
            _spawning = !_spawning;
        }

        public void SetGameOver()
        {
            _gameOver = true;
        }
    }
}