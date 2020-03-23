using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector3 movementVector;


        void Start()
        {

        }

        private void Update()
        {
            movementVector = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.W))
            {
                movementVector.y = 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                movementVector.y = -1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                movementVector.x = 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                movementVector.x = -1;
            }

            if (true)
            {
                transform.position += movementVector;
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
                UIController.instance.canvas.transform.position = transform.position;
            }
        }
    }
}