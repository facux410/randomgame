using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycube : MonoBehaviour
{
    jero player;
    void Start()
    {
        player = FindObjectOfType<jero>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
            
        }
        
        if (collision.gameObject.layer == 12)
        {
            if (!player.haveshield)
            {
                player.life1 -= 10f;
            }
            else
            {
                player.lifeshield--;
            }
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
