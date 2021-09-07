using Game.Player;
using UnityEngine;

namespace Core
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData bulletData;

        private void Start()
        {
            Destroy(gameObject, bulletData.bulletLife);
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            transform.position += transform.TransformDirection (Vector3.up) * (bulletData.bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<PlayerHealth>() == false || other.gameObject.CompareTag($"Enemy")) return;
            HitObject(other);
        }

        private void HitObject(Collider2D other)
        {
            other.GetComponent<PlayerHealth>().Damage();
            Destroy(gameObject);
        }
        
    }
}