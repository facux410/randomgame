using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootonmouse : MonoBehaviour
{
    public float nextfire;
    public float firerate;
    public shoot shoot;
    public Transform shootspawn;

    jero jero;

    private void Awake()
    {
        jero = FindObjectOfType<jero>();
    }
    void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextfire)
        {

            nextfire = Time.time + firerate;                
            shoot shooting = Instantiate<shoot>(shoot, shootspawn.position,transform.rotation);
            shooting.transform.right = this.transform.up;


        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    
}
