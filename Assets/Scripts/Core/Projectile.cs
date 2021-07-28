﻿using System;
using UnityEngine;

namespace Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData bulletData;
        [SerializeField] private float bulletLife;
        private bool _activated;
        private float _bulletSpeed;
        private float _bulletLife;
        

        private void Update()
        {
            MoveBullet();
            if (_bulletLife>=bulletLife)
            {
                PlayerProjectilePool.Add(gameObject);
            }
            _bulletLife += Time.deltaTime;
        }

        private void MoveBullet()
        {
            if (_activated) transform.position += transform.TransformDirection(Vector3.up) * (_bulletSpeed * Time.deltaTime);
        }

        public void Activate(float bulletSpeed)
        {
            //Debug.Log($"{gameObject.name} is activated! ");
            gameObject.SetActive(true);
            _bulletSpeed = bulletSpeed;
            _activated = true;
        }

        public void Deactivate()
        {
            //Debug.Log($"{gameObject.name} is deactivated! ");
            gameObject.SetActive(false);
            _bulletLife = 0;
            _activated = false;
        }
    }
}