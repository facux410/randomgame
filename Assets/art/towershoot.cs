using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towershoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    jero jero;
    public float firerate;
    public float nextfire;
    torret torreta;
    public float anglex;
    public float angley;
    public float timetolife;
    
    private void Awake()
    {
        jero = FindObjectOfType<jero>();
        torreta  = FindObjectOfType<torret>();
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;
        timetolife += Time.deltaTime;
        Timetodie();

        if(jero.lifeshield<= 0)
        {
            jero.haveshield = false;
            jero.fly = false;
            jero.countalas = 0;
            jero.lifeshield = 3;
        }

    }
    void Timetodie()
    {
        if(timetolife >= 5)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 12)
        {
            if (!jero.haveshield)
            {
                jero.life1 -= 10f;
            }
            else
            {
                jero.lifeshield--;
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }


    }

    
}
