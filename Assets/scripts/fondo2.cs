using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class fondo2 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    Color randomcolor;
    public float timer;
    public GameObject fondo;
    public Vector3 axisfondo;
    public float speed;

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
        Rotate();
        Pasalvl();
    }

    void Rotate()
    {
        transform.RotateAround(fondo.transform.position, axisfondo, speed * Time.deltaTime);
    }

    public void Pasalvl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("menu");
    }
}
