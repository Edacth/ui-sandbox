using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    public class UIHeart : UIObject
    {
        [SerializeField] float maxHealth;
        [SerializeField] float health;
        [SerializeField] TMPro.TMP_Text healthText;

        public void Start()
        {
            healthText.text = ((health / maxHealth) * 100).ToString() + "%";
        }
        public void TakeDamage(float _amount)
        {
            health -= _amount;
            healthText.text = ((health / maxHealth) * 100).ToString() + "%";
            if (health <= 0)
            {

            }
        }
    }
}
