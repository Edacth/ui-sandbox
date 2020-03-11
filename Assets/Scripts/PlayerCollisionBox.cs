using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerCollisionBox : MonoBehaviour
    {
        BoxCollider2D boxCollider;

        public delegate void ProjectileCollDel(RealProjectile _realProjectile, CARDINAL _receptionDir);
        public ProjectileCollDel onPlayerProjecileHit;

        [SerializeField] CARDINAL receptionDirection;

        void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(gameObject.name + " " + collision.name);
            if (onPlayerProjecileHit != null && collision.CompareTag("Projectile"))
            {
                RealProjectile realProjectile = collision.gameObject.GetComponent<RealProjectile>();
                if (realProjectile == null) { return; }
                onPlayerProjecileHit.Invoke(realProjectile, receptionDirection);
            }
        }
    }
}

