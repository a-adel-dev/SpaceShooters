using Game;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnCoolDown;
        [SerializeField] private float waveCoolDown;
        private readonly Timer _spawnTimer = new Timer();
        private readonly Timer _waveTimer = new Timer();
        private bool _spawning = true;
        

        private void Start()
        {
            SpawnObject();
            _spawnTimer.StartTimer(spawnCoolDown);
            _waveTimer.StartTimer(waveCoolDown);
        }

        private void SpawnObject()
        {
            if (_spawning)
            {
                int randomIndex = Random.Range(0, 3);
                AsteroidSize size = (AsteroidSize)randomIndex;
                SpawnAsteroids(size, 1);
            }
        }

        public void SpawnAsteroids(AsteroidSize size, int numberOfAsteroids)
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                GameObject asteroid = AsteroidPool.Get();
                asteroid.transform.position = transform.position;
                asteroid.GetComponent<AsteroidMover>().Push(transform.up);

                asteroid.GetComponent<Asteroid>().AsteroidSize = size;
                asteroid.GetComponent<Asteroid>().SetAsteroidSize();
                asteroid.GetComponent<AsteroidMover>().SetAsteroidSpeed();
                asteroid.GetComponent<AsteroidMover>().Activate();

                SpriteRenderer asteroidSpriteRenderer = asteroid.transform.GetChild(0).GetComponent<SpriteRenderer>();
                asteroidSpriteRenderer.sortingOrder = 2;
            }
        }

        private void Update()
        {
            _spawnTimer.Tick(Time.deltaTime);
            _waveTimer.Tick(Time.deltaTime);
            if (_spawnTimer.Finished)
            {
                //TODO - create asteroid pool
                SpawnObject();
                _spawnTimer.ResetTimer(spawnCoolDown);
            }

            if (!_waveTimer.Finished) return;
            _waveTimer.ResetTimer(waveCoolDown);
            _spawning = !_spawning;
        }
    }
}