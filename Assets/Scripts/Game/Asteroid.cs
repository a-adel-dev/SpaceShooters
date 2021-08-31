using System;
using UnityEngine;
using Core;
using Random = UnityEngine.Random;

namespace Game
{
    public class Asteroid : MonoBehaviour, IDamageble
    {
        private float _asteroidLife;
        public AsteroidSize AsteroidSize { get; set; }


        private void Update()
        {
            _asteroidLife += Time.deltaTime;
        }

        public void SetAsteroidSize()
        {
            if (AsteroidSize == AsteroidSize.Medium)
            {
                transform.localScale *= 0.5f;
                return;
            }

            if (GetComponent<Asteroid>().AsteroidSize == AsteroidSize.Small)
            {
                transform.localScale *= 0.25f;
            }
        }

        public void Damage()
        {
            switch (AsteroidSize)
            {
                case AsteroidSize.Big:
                    SpawnAsteroids( AsteroidSize.Medium, 2);
                    Destroy(gameObject);
                    break;
                case AsteroidSize.Medium:
                    SpawnAsteroids( AsteroidSize.Small, 2);
                    Destroy(gameObject);
                    break;
                default:
                    AsteroidPool.Add(gameObject);
                    break;
            }
        }
        
        private void SpawnAsteroids(AsteroidSize size, int numberOfAsteroids)
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                GameObject asteroid = AsteroidPool.Get();
                asteroid.transform.position = transform.position;
                Vector3 direction = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0);
                asteroid.GetComponent<AsteroidMover>().Push(direction);

                asteroid.GetComponent<Asteroid>().AsteroidSize = size;
                asteroid.GetComponent<Asteroid>().SetAsteroidSize();
                asteroid.GetComponent<AsteroidMover>().SetAsteroidSpeed();
                asteroid.GetComponent<AsteroidMover>().Activate();

                SpriteRenderer asteroidSpriteRenderer = asteroid.transform.GetChild(0).GetComponent<SpriteRenderer>();
                asteroidSpriteRenderer.sortingOrder = 2;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_asteroidLife < 1f || other.CompareTag("Enemy"))
            {
                return;
            }
            if (other.CompareTag("Player"))
            {
                other.GetComponent<IDamageble>().Damage();
                Damage();
            }

        }
    }
}