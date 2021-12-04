using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fondo : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    Color randomcolor;
    public float timer;
    
    
    void changecolor()
    {
        if (spriterenderer != null)
        {
            randomcolor = new Color(Random.value, Random.value, Random.value);//*speed * Time.deltaTime;
        }

    }
    void Timeres()
    {

       if (timer >= 1)
       {
            spriterenderer.color = randomcolor;
            timer = 0;
       }
    }
        
    void Update()
    {
        timer += Time.deltaTime;
        changecolor();
        Timeres();
        Pasalvl();
    }
    public void Pasalvl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("menu");
    }

}
