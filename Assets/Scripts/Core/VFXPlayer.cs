using System;
using UnityEngine;

namespace Core
{
    public class VFXPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject fxPrefab;
        [SerializeField] private float vfxPlayTime;
        public void PLayFX()
        {
            var explosion = Instantiate(fxPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, vfxPlayTime);
        }
    }
}