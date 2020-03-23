using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIProjectile : UIObject
    {
        [SerializeField] public CARDINAL direction;
        [SerializeField] protected float speed;

        private void Awake()
        {
            UIObjectInit();
        }

        private void FixedUpdate()
        {
            Move();
            DetectCollision();
        }

        public void Init(Vector3 _position, CARDINAL _direction, float _speed)
        {
            rectTransform.position = _position;
            direction = _direction;
            speed = _speed;
        }

        protected void Move()
        {
            transform.position += DirectionDict.dirDict[direction] * speed;
        }

        void DetectCollision()
        {
            UIObject[] overlapObjects = UIController.instance.GetOverlappingUIObjects(this);
            if (overlapObjects.Length > 0)
            {
                Debug.Log("");
            }
        }

        void OnHit()
        {
            throw new System.NotImplementedException();
        }
    }
}

