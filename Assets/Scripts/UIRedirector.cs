using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIRedirector : UIObject
    {
        public CARDINAL direction;

        private void Start()
        {
            transform.eulerAngles = DirectionDict.rotDict[direction];
            Selected = false;
        }

        public void Redirect(GameObject _gameObject, UIProjectile _projectile)
        {
            //UIProjectile uIProjectile = Instantiate(_original, transform.position + DirectionDict.dirDict[direction], Quaternion.identity).GetComponent<UIProjectile>();
            //uIProjectile.Init()
            _gameObject.transform.position = transform.position + DirectionDict.vecDict[direction] * 1f;
            _gameObject.transform.eulerAngles = DirectionDict.rotDict[direction];
            _projectile.direction = direction;
        }
    }
}

