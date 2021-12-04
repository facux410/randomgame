using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    
    jero jero;
    SpriteRenderer sprite;

    bool shootx;
    float timetodie;
    
    private void Awake()
    {

        
        jero = FindObjectOfType<jero>();
        

    }

    void Start()
    {
        sprite = FindObjectOfType<SpriteRenderer>();

       
        
    }
    void Timetodiebro()
    {
        if (timetodie >= 5)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        timetodie+=Time.deltaTime;

        transform.position += transform.right * (speed * Time.deltaTime);

        Timetodiebro();



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 16 || collision.gameObject.layer == 17|| collision.gameObject.layer == 18|| collision.gameObject.layer == 19)
        {
            jero.countalas += 10;
            Destroy(gameObject);
        }
    }




}
