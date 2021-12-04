using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dianaslvl1 : MonoBehaviour
{
    public Transform[] spawn = new Transform[6] ;
    public GameObject diana;
    jero jero;
    void Start()
    {
        jero = FindObjectOfType<jero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangePosition()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            jero.countalas += 10;
            Destroy(gameObject);
            
            
        }
    }
}
