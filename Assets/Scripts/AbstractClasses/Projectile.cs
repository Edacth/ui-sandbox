using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] public CARDINAL direction;
        [SerializeField] protected float speed;

        void FixedUpdate()
        {
            Move();
        }

        public abstract void Init(Vector3 _position, CARDINAL _direction, float _speed);

        protected abstract void Move();
    }
}