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
            if ( UIProjecile == null ) { Debug.LogError("UIProjectile is null", this); return; }
            UIProjectile projectile = Instantiate(UIProjecile, UIController.instance.canvas.transform).GetComponent<UIProjectile>();
            projectile.Init(rectTransform.position, direction, 0.1f);
        }
    }
}