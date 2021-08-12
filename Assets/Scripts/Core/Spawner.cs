﻿using Unity.Mathematics;
using UnityEngine;

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
            _spawnTimer.StartTimer(spawnCoolDown);
            _waveTimer.StartTimer(waveCoolDown);
        }

        private void SpawnObject()
        {
            if (_spawning)
            {
                Instantiate(spawnedObjectPrefab, transform.position, quaternion.identity);
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