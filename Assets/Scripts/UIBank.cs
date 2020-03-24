using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIBank : UIObject
    {
        [SerializeField] int coinCount;
        [SerializeField] TMPro.TMP_Text coinText;

        public void IncreaseCount(int amount)
        {
            coinCount += amount;
            coinText.text = coinCount.ToString();
        }
    }
}

