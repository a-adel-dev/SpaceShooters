using UnityEngine;

namespace Game.Player
{
    public class PlayerVFX : MonoBehaviour
    {
        [SerializeField] private float vfxPlayTime;
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private GameObject hitPrefab;
        
        public void PlayExplosionFX()
        {
            var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, vfxPlayTime);
        }

        public void PlayHitFX()
        {
            GameObject hitFX = Instantiate(hitPrefab, transform.position, Quaternion.identity);
            hitFX.transform.parent = gameObject.transform;
            Destroy(hitFX, vfxPlayTime);
        }
    }
}