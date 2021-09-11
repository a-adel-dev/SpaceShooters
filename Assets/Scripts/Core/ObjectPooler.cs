using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            [FormerlySerializedAs("tag")] public PoolTypes poolType;
            public GameObject prefab;
            public int size;
        }

        #region Singleton
        
        public static ObjectPooler Instance;

        private void Awake()
        {
            Instance = this;
            Initialize();
        }
        
        #endregion

        public List<Pool> pools;
        public Dictionary<PoolTypes, Queue<GameObject>> poolDictionary = new Dictionary<PoolTypes, Queue<GameObject>>();

        private void Initialize()
        {
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, gameObject.transform, true);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                
                poolDictionary.Add(pool.poolType, objectPool);
            }
        }

        public GameObject SpawnFromPool(PoolTypes poolType, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(poolType))
            {
                Debug.LogWarning($"Pool with tag {poolType} does not exist.");
                return null;
            }
            
            GameObject objectToSpawn =  poolDictionary[poolType].Dequeue();
            
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            poolDictionary[poolType].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}