using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    public jero target;
    public camera camera2;
    

    BOSS jefe;
    private void Start()
    {
        jefe = FindObjectOfType<BOSS>();
    }

    void Update()
    {
        if (target != null && !jefe.atack)
        {
            transform.position = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);

        }

        

    }

}
