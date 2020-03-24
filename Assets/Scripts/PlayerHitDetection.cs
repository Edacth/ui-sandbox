using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerHitDetection : MonoBehaviour
    {
        [SerializeField] PlayerCollisionBox[] collisionBoxes;

        void Start()
        {
            for (int i = 0; i < collisionBoxes.Length; i++)
            {
                collisionBoxes[i].onPlayerProjecileHit += PlayerHit;
            }
        }

        void PlayerHit(RealProjectile _realProjectile, CARDINAL _receptionDir)
        {
            Debug.Log(_receptionDir);
            UIController.instance.ShootInUI(_receptionDir, _realProjectile.type);
        }
    }
}


