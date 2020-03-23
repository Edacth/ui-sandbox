using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RealProjectile : MonoBehaviour
    {
        [SerializeField] public CARDINAL direction;
        [SerializeField] protected float speed;

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerCollisionBox _playerCollisionBox;
                if (other.TryGetComponent(out _playerCollisionBox))
                {
                    _playerCollisionBox.OnProjectileHit(this);
                }

                OnHit();
            }
        }

        public void Init(Vector3 _position, CARDINAL _direction, float _speed)
        {
            transform.position = _position;
            direction = _direction;
            speed = _speed;
        }

        protected void Move()
        {
            transform.position += DirectionDict.dirDict[direction] * speed;
        }

        private void OnHit()
        {
            Destroy(gameObject);
        }
    }
}