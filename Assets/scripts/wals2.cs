using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wals2 : MonoBehaviour
{
    public float[] posX2 = new float[2];

    public GameObject walls2;

    void Update()
    {
        if (transform.position.x >= posX2[1])
        {
            movewals2();
        }


    }
    void movewals2()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
    }
    
}
