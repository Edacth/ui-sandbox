using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIFurnace : UIObject
    {
        [SerializeField] GameObject UIProjecile;
        [SerializeField] CARDINAL direction;
        [SerializeField] int fuelCount = 0;
        [SerializeField] int oreCount = 0;
        [SerializeField] float smeltInterval = 0;
        [SerializeField] float smeltTime;

        private void Start()
        {
            Selected = false;
            transform.eulerAngles = DirectionDict.rotDict[direction];

        }

        private void FixedUpdate()
        {
            if (Time.time - smeltTime >= smeltInterval)
            {  
                smeltTime = Time.time;
                if (fuelCount >= 1 && oreCount >= 1)
                {
                    Smelt();
                }
            }
        }

        void Smelt()
        {
            if (UIProjecile == null) { Debug.LogError("UIProjectile is null", this); return; }
            UIProjectile projectile = Instantiate(UIProjecile, UIController.instance.canvas.transform).GetComponent<UIProjectile>();
            projectile.Init(rectTransform.position + DirectionDict.vecDict[direction], direction, PROJTYPE.Coin, 0.1f);
            fuelCount--;
            oreCount--;
        }

        public void IncreaseFuel(int amount)
        {
            fuelCount += amount;
        }
        public void IncreaseOre(int amount)
        {
            oreCount += amount;
        }
    }
}