using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIShooter : UIObject
    {
        public CARDINAL direction;
        [SerializeField] GameObject UIProjecile;
        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Shoot()
        {
            Debug.Log("Shoot");
            UIProjectile projectile = Instantiate(UIProjecile, UIController.instance.canvas.transform).GetComponent<UIProjectile>();
            projectile.Init(rectTransform.position, direction);
        }
    }
}