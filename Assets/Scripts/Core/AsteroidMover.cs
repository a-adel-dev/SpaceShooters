using System;
using UnityEngine;
using Utils;

namespace Core
{
    public class AsteroidMover : MonoBehaviour
    {
        [SerializeField] private float asteroidBaseSpeed;
        private Vector3 _movementDirection;
        public bool screenBound;
        private Bounds screenBounds;
        Vector3 _direction;
        Vector3 lastPosition;

        private void Start()
        {
            screenBounds = new Bounds(Camera.main.transform.position,
                new Vector3(ScreenUtils.ScreenRight * 2, ScreenUtils.ScreenTop * 2, Mathf.Infinity));
        }

        private void Update()
        {
            HandleMovement();
            InScreenBounds();
            
        }

        private void HandleMovement()
        {
            transform.position += transform.TransformDirection (_movementDirection) * (asteroidBaseSpeed * Time.deltaTime);
            
            if (screenBound)
            {
                if (transform.position.x > ScreenUtils.ScreenRight)
                {
                    Push(Vector3.Reflect(_direction, Vector3.left));
                }

                if (transform.position.x < ScreenUtils.ScreenLeft )
                {
                    Push(Vector3.Reflect(_direction, Vector3.right));
                }

                if (transform.position.y > ScreenUtils.ScreenTop)
                {
                    Push(Vector3.Reflect(_direction, Vector3.down));
                }

                if (transform.position.y < ScreenUtils.ScreenBottom)
                {
                    Push(Vector3.Reflect(_direction, Vector3.up));
                }
            }
        }

        private void FixedUpdate()
        {
            _direction = (transform.position - lastPosition).normalized;
            lastPosition = transform.position;
        }

        public void Push(Vector3 direction)
        {
            _movementDirection = direction;
        }
        
        private void InScreenBounds()
        {
            if (screenBound)
            {
                return;
            }
            if (screenBounds.Contains(transform.position))
                screenBound = true;
        }
    }
}