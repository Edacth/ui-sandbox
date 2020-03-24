using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DirectionDict : MonoBehaviour
    {
        public static Dictionary<CARDINAL, Vector3> vecDict = new Dictionary<CARDINAL, Vector3>();
        public static Dictionary<CARDINAL, Vector3> rotDict = new Dictionary<CARDINAL, Vector3>();

        private void Awake()
        {
            vecDict.Add(CARDINAL.North, Vector3.up);
            vecDict.Add(CARDINAL.East, Vector3.right);
            vecDict.Add(CARDINAL.South, Vector3.down);
            vecDict.Add(CARDINAL.West, Vector3.left);

            rotDict.Add(CARDINAL.North, new Vector3(0, 0, -90));
            rotDict.Add(CARDINAL.East, new Vector3(0, 0, 180));
            rotDict.Add(CARDINAL.South, new Vector3(0, 0, 90));
            rotDict.Add(CARDINAL.West, new Vector3(0, 0, 0));
        }
    }
}