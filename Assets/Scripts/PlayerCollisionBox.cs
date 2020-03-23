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

        public void OnProjectileHit(RealProjectile _realProjectile)
        {
            if (onPlayerProjecileHit != null)
            {
                if (_realProjectile == null) { return; }
                onPlayerProjecileHit.Invoke(_realProjectile, receptionDirection);
            }
        }
    }
}

