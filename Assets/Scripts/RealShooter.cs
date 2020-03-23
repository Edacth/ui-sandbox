using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RealShooter : MonoBehaviour
    {
        public CARDINAL direction;
        [SerializeField] GameObject projectile;
        [SerializeField] float shootInterval;
        float shootTime;

        private void Start()
        {
            shootTime = Time.time;
        }

        private void FixedUpdate()
        {
            if (Time.time - shootTime >= shootInterval)
            {
                Shoot();
                shootTime = Time.time;
            }
        }

        private void Shoot()
        {
            if (projectile == null) { Debug.LogError("UIProjectile is null", this); return; }
            RealProjectile _projectile = Instantiate(projectile).GetComponent<RealProjectile>();
            _projectile.Init(transform.position, direction, 0.1f);
        }
    }
}
