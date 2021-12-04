using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraX : MonoBehaviour
{
    public jero target1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target1.transform.position.x+5, 0, transform.position.z);
    }
}
