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

        public override void Init(Vector3 _position, CARDINAL _direction, float _speed)
        {
            rectTransform.position = _position;
            direction = _direction;
            speed = _speed;
        }

        protected override void Move()
        {
            transform.position += DirectionDict.dirDict[direction] * speed;
        }
    }
}

