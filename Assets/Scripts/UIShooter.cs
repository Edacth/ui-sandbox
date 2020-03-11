using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIShooter : UIObject
    {
        public CARDINAL direction;
        [SerializeField] GameObject UIProjecile;

        public void Shoot()
        {
            Debug.Log("Shoot");
            UIProjectile projectile = Instantiate(UIProjecile).GetComponent<UIProjectile>();
            projectile.Init(direction);
        }
    }
}