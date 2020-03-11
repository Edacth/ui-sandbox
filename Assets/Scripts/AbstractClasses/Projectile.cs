using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Projectile : MonoBehaviour
    {
        

        public CARDINAL direction;
        float speed;

        

        public void Init(Vector3 _position, CARDINAL _direction)
        {
            rectTransform.position = _position;
            direction = _direction;
        }

        void FixedUpdate()
        {
            
            Move();
        }

        protected abstract void Move();
    }
}