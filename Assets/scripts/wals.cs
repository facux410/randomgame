using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wals : MonoBehaviour
{
    public float[] posX = new float[2];

    public GameObject walls;

    void Update()
    {
        if (transform.position.x <= posX[1])
        {
            movewals();
        }


    }
    void movewals()
    {
        transform.position += new Vector3(1,0,0)* Time.deltaTime;
        
        

        

    }
}
