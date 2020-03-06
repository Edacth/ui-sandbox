using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    bool selected { get; set; }

    void Select();
    void Deselect();

    void Move();
}
