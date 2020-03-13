using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIShooter : UIObject
    {
        public CARDINAL direction;
        [SerializeField] GameObject UIProjecile;

        private void Awake()
        {
            UIObjectInit();
        }

        public void Shoot()
        {
            Debug.Log("Shoot");
            UIProjectile projectile = Instantiate(UIProjecile, UIController.instance.canvas.transform).GetComponent<UIProjectile>();
            projectile.Init(rectTransform.position, direction, 10f);
        }
    }
}