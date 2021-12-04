using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arealvlthis : MonoBehaviour
{
    jero jerolvl2;
    void Start()
    {
        jerolvl2 = FindObjectOfType<jero>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
            jerolvl2.lvl2 = true;
    }

    
    void Update()
    {
        
    }
}
