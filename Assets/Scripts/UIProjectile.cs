using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIProjectile : UIObject
    {
        [SerializeField] public CARDINAL direction;
        [SerializeField] public PROJTYPE type;
        [SerializeField] protected float speed;
        [SerializeField] Sprite[] sprites;

        private void Awake()
        {
            UIObjectInit();
        }

        private void FixedUpdate()
        {
            Move();
            DetectCollision();
        }

        public void Init(Vector3 _position, CARDINAL _direction, PROJTYPE _type, float _speed)
        {
            rectTransform.position = _position;
            direction = _direction;
            speed = _speed;
            type = _type;
            spriteRenderer.sprite = sprites[(int)type];
            transform.eulerAngles = DirectionDict.rotDict[direction];
        }

        protected void Move()
        {
            transform.position += DirectionDict.vecDict[direction] * speed;
        }

        void DetectCollision()
        {
            UIObject[] overlapObjects = UIController.instance.GetOverlappingUIObjects(this);
            for (int i = 0; i < overlapObjects.Length; i++)
            {
                if (overlapObjects[i].CompareTag("Heart"))
                {
                    UIHeart _UIHeart;
                    if (overlapObjects[i].TryGetComponent(out _UIHeart))
                    {
                        _UIHeart.TakeDamage(10);
                    }
                    OnHit();
                }
                else if (overlapObjects[i].CompareTag("Redirector"))
                {
                    UIRedirector _UIRedirector;
                    if(overlapObjects[i].TryGetComponent(out _UIRedirector))
                    {
                        _UIRedirector.Redirect(gameObject, this);
                    }
                }
                else if (overlapObjects[i].CompareTag("Furnace"))
                {
                    UIFurnace _UIFurnace;
                    if (overlapObjects[i].TryGetComponent(out _UIFurnace))
                    {
                        switch (type)
                        {
                            case PROJTYPE.Fire:
                                _UIFurnace.IncreaseFuel(1);
                                break;
                            case PROJTYPE.Rock:
                                _UIFurnace.IncreaseOre(1);
                                break;
                            case PROJTYPE.Coin:
                                break;
                            default:
                                break;
                        }
                    }
                    OnHit();
                }
                else if (overlapObjects[i].CompareTag("Bank"))
                {
                    UIBank _UIBank;
                    if (overlapObjects[i].TryGetComponent(out _UIBank))
                    {
                        _UIBank.IncreaseCount(1);
                    }
                    OnHit();
                }
            }
        }

        void OnHit()
        {
            Destroy(gameObject);
        }
    }
}

