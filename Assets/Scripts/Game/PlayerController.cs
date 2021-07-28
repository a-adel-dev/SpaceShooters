using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        public Ship currentShip { get; set; }
        public SpriteRenderer ExhaustSpriteRenderer { get; set; }
        
        private float _movementInput;
        private float _rotationInput;
        private float _movementThrottle;
        

        private void Update()
        {
            HandleMovement();
            HandleRotation();
            ConfigureMovementThrottle();
        }

        private void HandleMovement()
        {
            transform.position += transform.up * (_movementThrottle * currentShip.thrustSpeed * Time.deltaTime);
        }
        
        public void OnMovement(InputAction.CallbackContext value)
        {
            _movementInput = value.ReadValue<float>();
        }

        private void ConfigureMovementThrottle()
        {
            if (_movementInput > 0)
            {
                _movementThrottle += currentShip.movementThrottleMultiplier * Time.deltaTime;
            }else if (_movementInput is 0)
            {
                _movementThrottle -= _movementThrottle * Time.deltaTime;
            }
            else
            {
                _movementThrottle -= currentShip.brakeMultiplier * Time.deltaTime;
            }

            _movementThrottle = Mathf.Clamp(_movementThrottle, 0, currentShip.maxMovementThrottle);

                    
            float thrust = Mathf.InverseLerp(0f, 1f, _movementThrottle);
            ExhaustSpriteRenderer.material.color = new Color(1f, 1f, 1f, thrust );
        }

        void HandleRotation()
        {
            transform.Rotate(Vector3.forward, -currentShip.rotationSpeed * _rotationInput * Time.deltaTime);
        }

        public void OnRotate(InputAction.CallbackContext value)
        {
            _rotationInput = value.ReadValue<float>();
        }


    }
}