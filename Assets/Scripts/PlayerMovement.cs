using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movementVector;
    

    void Start()
    {
        
    }

    private void FixedUpdate()
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
            
        }
        
    }
}
