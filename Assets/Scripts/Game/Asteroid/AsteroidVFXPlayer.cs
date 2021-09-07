using UnityEngine;

namespace Game.Asteroid
{
    public class AsteroidVFXPlayer : MonoBehaviour
    {
        [SerializeField] private float vfxPlayTime;
        [SerializeField] private GameObject explosionPrefab;
        public void PlayExplosionFX()
        {
            var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, vfxPlayTime);
        }
    }
}