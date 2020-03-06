using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour, IMoveable
{
    public bool selected { get; set; }
    Vector3 movementVector;
    float movementSpeed = 0.5f;

    void Start()
    {
        Select();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }

    public void Move()
    {
        movementVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementVector.y = movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVector.y = -movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -movementSpeed;
        }

        if (true)
        {
            transform.position += movementVector;

        }
    }
}
