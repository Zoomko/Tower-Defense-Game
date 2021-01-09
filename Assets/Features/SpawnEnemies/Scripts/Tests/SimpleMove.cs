using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Vector3 Direction = new Vector3(1, 0, 0);

    void FixedUpdate()
    {
        transform.Translate(Direction);
    }
}
