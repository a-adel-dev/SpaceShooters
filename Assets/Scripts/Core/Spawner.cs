using Game;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnedObjectPrefab;
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
                GameObject asteroid =  Instantiate(spawnedObjectPrefab, transform.position, quaternion.identity);
                asteroid.GetComponent<AsteroidMover>().Push(transform.up);
                int randomIndex = Random.Range(0, 3);
                asteroid.GetComponent<Asteroid>().AsteridSize = (AsteroidSize) randomIndex;
                asteroid.GetComponent<Asteroid>().SetAsteroidSize();
                asteroid.GetComponent<AsteroidMover>().SetAsteroidSpeed();
                
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