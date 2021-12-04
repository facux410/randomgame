using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {

    public GameObject Camera;
    public jero jero;
    SceneManager scene;
    private void Awake()
    {
        Camera = GameObject.Find("jero");

    }

    public void Playgame()
    {
        SceneManager.LoadScene(3);

    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    

    
    
}
