using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIProjectile : Projectile
    {
        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        protected override void Move()
        {
            transform.position += DirectionDict.dirDict[direction];
        }
    }
}

