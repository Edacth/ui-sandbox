using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIProjectile : MonoBehaviour
    {
        public CARDINAL direction;
        float speed;

        public void Init(CARDINAL _direction)
        {
            direction = _direction;
        }

        void FixedUpdate()
        {
            transform.position += DirectionDict.dirDict[direction];
        }
    }
}

