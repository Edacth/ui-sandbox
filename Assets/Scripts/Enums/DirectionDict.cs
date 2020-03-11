using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DirectionDict : MonoBehaviour
    {
        public static Dictionary<CARDINAL, Vector3> dirDict = new Dictionary<CARDINAL, Vector3>();

        private void Awake()
        {
            dirDict.Add(CARDINAL.North, Vector3.up);
            dirDict.Add(CARDINAL.East, Vector3.right);
            dirDict.Add(CARDINAL.South, Vector3.down);
            dirDict.Add(CARDINAL.West, Vector3.left);
        }
    }
}