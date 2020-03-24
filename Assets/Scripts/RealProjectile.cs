using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RealProjectile : MonoBehaviour
    {
        [SerializeField] public CARDINAL direction;
        [SerializeField] public PROJTYPE type;
        [SerializeField] protected float speed;
        [SerializeField] Sprite[] sprites;

        SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

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

        public void Init(Vector3 _position, CARDINAL _direction, PROJTYPE _type, float _speed)
        {
            transform.position = _position;
            direction = _direction;
            speed = _speed;
            type = _type;
            spriteRenderer.sprite = sprites[(int)type];
        }

        protected void Move()
        {
            transform.position += DirectionDict.vecDict[direction] * speed;
        }

        private void OnHit()
        {
            Destroy(gameObject);
        }
    }
}