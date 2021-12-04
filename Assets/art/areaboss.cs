using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaboss : MonoBehaviour
{
    BOSS boss;
    jero jerox;
    Camera cam;
    public Transform poscam;
    private void Awake()
    {
        boss = FindObjectOfType<BOSS>();
        jerox = FindObjectOfType<jero>();
        cam = FindObjectOfType<Camera>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            boss.atack = true;

            jerox.rb.gravityScale = 1;
        }


    }

    private void Update()
    {
        if (boss.atack)
        {
            if(cam.orthographicSize < 23)
            {
                cam.orthographicSize += Time.deltaTime  *2;

            }
            if (cam.transform.position.y < poscam.position.y)
            {
                var dir = poscam.position - cam.transform.position;
                cam.transform.position += dir.normalized * Time.deltaTime * 8;

            }
            else
            {
                cam.transform.position = poscam.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            boss.atack = false;
        }
    }
}
