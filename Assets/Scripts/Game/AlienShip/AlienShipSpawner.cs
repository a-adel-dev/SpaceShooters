using Core;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.AlienShip
{
    public class AlienShipSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnCoolDown;
        private readonly Timer _spawnTimer = new Timer();
        [SerializeField] private GameObject ShipPrefab;
        private bool _gameOver;

        private void Start()
        {
            _spawnTimer.StartTimer(Random.Range(Mathf.Max(10,spawnCoolDown-10), spawnCoolDown +10) );
        }

        private void SpawnShip()
        {
            Instantiate(ShipPrefab, transform.position, quaternion.identity);
        }

        private void Update()
        {
            if (_gameOver is true)
            {
                return;
            }
            _spawnTimer.Tick(Time.deltaTime);
            if (_spawnTimer.Finished)
            {
                SpawnShip();
                _spawnTimer.ResetTimer(spawnCoolDown);
            }
        }
        
        public void SetGameOver()
        {
            _gameOver = true;
        }
    }
}