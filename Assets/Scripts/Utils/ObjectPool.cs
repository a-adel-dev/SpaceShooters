using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class ObjectPool
    {
        private Queue<GameObject> pool = new Queue<GameObject>();
        private readonly GameObject _template;
        private int counter;

        public ObjectPool(GameObject template)
        {
            _template = template;
            FillPool();
        }
        
        public void AddToPool(GameObject o)
        {
            pool.Enqueue(o);
        }

        public GameObject GetFromPool()
        {
            if (pool.Count < 30)
            {
                FillPool();
            }
            return pool.Dequeue();
        }

        private void FillPool()
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject o = GameObject.Instantiate(_template);
                o.name = counter.ToString();
                AddToPool(o);
                counter++;
            }
        }

        public int GetNumObjectsInQueue()
        {
            return pool.Count;
        }
    }
}