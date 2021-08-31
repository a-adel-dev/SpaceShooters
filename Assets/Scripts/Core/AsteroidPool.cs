using UnityEngine;
using Utils;

namespace Core
{
    public static class AsteroidPool
    {
        private static ObjectPool asteroidPool;
        
        public static void Add(GameObject asteroid)
        {
            asteroidPool.AddToPool(asteroid);
            asteroid.SetActive(false);
            asteroid.GetComponent<AsteroidMover>().Deactivate();
        }
        
        public static GameObject Get()
        {
            return asteroidPool.GetFromPool();
        }
        
        public static void Initialize(GameObject asteroid)
        {
            asteroidPool = new ObjectPool(asteroid);
        }

        public static int GetNumObjectsInQueue()
        {
            return asteroidPool.GetNumObjectsInQueue();
        }
    }
}