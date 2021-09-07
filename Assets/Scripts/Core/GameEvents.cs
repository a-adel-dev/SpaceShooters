using System;
using UnityEngine;

namespace Core
{
    public static class GameEvents
    {

        public static Action<int> onEnemyDestroyed;

        public static void EnemyDestroyed(int score)
        {
            onEnemyDestroyed?.Invoke(score);
        }
        
        
    }
}