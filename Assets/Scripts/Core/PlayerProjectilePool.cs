using UnityEngine;
using Utils;

namespace Core
{
    public static class PlayerProjectilePool
    {
        private static ObjectPool bulletPool;

        public static void Add(GameObject bullet)
        {
            bulletPool.AddToPool(bullet);
            bullet.GetComponent<Projectile>().Deactivate();
        }

        public static GameObject Get()
        {
            return bulletPool.GetFromPool();
        }

        public static void Initialize(GameObject bullet)
        {
            bulletPool = new ObjectPool(bullet);
        }

        public static int GetNumObjectsInQueue()
        {
            return bulletPool.GetNumObjectsInQueue();
        }
    }
}