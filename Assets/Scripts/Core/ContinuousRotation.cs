using System;
using UnityEngine;

namespace Core
{
    public class ContinuousRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private void Update()
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}