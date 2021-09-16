using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Data
{
    public class ProgressionController : MonoBehaviour
    {
        [SerializeField] private int[] SpawnCoolDown = { 5, 4, 3 };
        [SerializeField] private int[] WaveCoolDown = { 10, 8, 7 };

        [SerializeField] private float easyTime = 30f;
        [SerializeField] private float mediumTime = 60f;
        public UnityEvent<int,int> gameStateChanged;
        
        public int CurrentSpawnCd { get; set; }
        public int CurrentWaveCd { get; set; }

        private float _gameTime = 0;
        private GameState _gameState = GameState.None;

        private void Start()
        {
            _gameState = GameState.Easy;
            SetGameDifficulty();
        }

        private void Update()
        {
            _gameTime += Time.deltaTime;
            if (_gameState == GameState.Easy && _gameTime >= easyTime)
            {
                _gameState = GameState.Medium;
                SetGameDifficulty();
            }

            if (_gameState == GameState.Medium && _gameTime >= mediumTime)
            {
                _gameState = GameState.Hard;
                SetGameDifficulty();
            }
        }

        private void SetGameDifficulty()
        {
            CurrentSpawnCd = SpawnCoolDown[(int)_gameState - 1];
            CurrentWaveCd = WaveCoolDown[(int)_gameState - 1 ];
            gameStateChanged?.Invoke(CurrentSpawnCd, CurrentWaveCd);
        }
        
    }
}