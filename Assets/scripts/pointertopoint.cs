using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointertopoint : MonoBehaviour
{
    public Vector3 posmouseinscreen;

    void MouseLook()
    {
        posmouseinscreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posmouseinscreen.z = transform.position.z;

        posmouseinscreen -= transform.position;

        transform.up = posmouseinscreen;
    }
    
    void Update()
    {
        MouseLook();
    }
}
