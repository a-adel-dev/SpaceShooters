using System;
using Game;
using UnityEngine;
using Utils;

namespace Core
{
    public class AsteroidMover : MonoBehaviour
    {
        [SerializeField] private float asteroidBaseSpeed;
        [SerializeField] private float mediumAsteroidSpeedModifier;
        [SerializeField] private float smallAsteroidSpeedModifier;
        
        private float _speed;
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

        public void SetAsteroidSpeed()
        {
            _speed = asteroidBaseSpeed;
            if (GetComponent<Asteroid>().AsteridSize == AsteroidSize.Medium)
            {
                _speed = asteroidBaseSpeed * mediumAsteroidSpeedModifier;
                return;
            }

            if (GetComponent<Asteroid>().AsteridSize == AsteroidSize.Small)
            {
                _speed = asteroidBaseSpeed * smallAsteroidSpeedModifier;
            }
        }

        private void Update()
        {
            HandleMovement();
            InScreenBounds();
            
        }

        private void HandleMovement()
        {
            transform.position += transform.TransformDirection (_movementDirection) * (_speed * Time.deltaTime);
            
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