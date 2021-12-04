using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fueguito : MonoBehaviour
{
    public Vector3 direccion;
    public Vector3 direccionFire;
    public GameObject boss;
    public GameObject fire;
    public float speed;
    public float speedfirerot;
    public SpriteRenderer spr;
    public float timer;
    public float count;
    jero jero;
    Vector3 target;
    Vector3 posinitial;
    Rigidbody2D rb;
    public float speedatack;

    float distance;

    

    BOSS bossy;

    public Transform[] posinicial = new Transform[1];





    public float visionray;
    public float speedfire;



    private void Start()
    {
        jero = FindObjectOfType<jero>();
        posinitial = transform.position;
        bossy= FindObjectOfType<BOSS>();
    }
    void Rotateboss()
    {
       if (bossy.stoprotate==true)
            transform.RotateAround(boss.transform.position, direccion, speed * Time.deltaTime);
    }
    void Rotateon()
    {
       if (bossy.stoprotate==true)
            transform.RotateAround(fire.transform.position, direccionFire, speedfirerot * Time.deltaTime);
    }

    void Fakeanim()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            count++;
            timer = 0;
        }

        count = (int)count;
        if (count == 4)
        {
            count = 0;
        }


        if (count % 2 == 0)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false;
        }
    }


    
    void Update()
    {
        count += 1 * Time.deltaTime;
        Rotateboss();
        Rotateon();
        Fakeanim();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            jero.life1 -= 25;
            Destroy(gameObject);
            bossy.stoprotate = true;
        }
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
            bossy.stoprotate = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
}
