using UnityEngine;
using Core;

namespace Game
{
    public class Asteroid : MonoBehaviour
    {
        public AsteroidSize AsteridSize { get; set; }

        public void SetAsteroidSize()
        {
            if (AsteridSize == AsteroidSize.Medium)
            {
                transform.localScale *= 0.5f;
                return;
            }

            if (GetComponent<Asteroid>().AsteridSize == AsteroidSize.Small)
            {
                transform.localScale *= 0.25f;
            }
        }
    }
}