using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AlienShipSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnCoolDown;
        private readonly Timer _spawnTimer = new Timer();
        [SerializeField] private GameObject ShipPrefab;

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
            _spawnTimer.Tick(Time.deltaTime);
            if (_spawnTimer.Finished)
            {
                SpawnShip();
                _spawnTimer.ResetTimer(spawnCoolDown);
            }
        }
    }
}