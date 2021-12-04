using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class BOSS : MonoBehaviour
{
    
    
    public float speed;
    public float speedfirerot;
    
    
    jero jero;
    Vector3 target;
    Vector3 posinitial;
    Rigidbody2D rb;
    public float speedatack;

    float distance;


    public float countshoot;
    public float countrotate;



    public float visionray;
    public float speedfire;

    public GameObject[] fires = new GameObject[6];

    public bool stoprotate = true;

    public GameObject prefab1;
    public GameObject prefab2;

    bool activefire0;
    bool activefire1;
    bool activefire2;
    bool activefire3;
    bool activefire4;
    bool activefire5;

    int countfire;

    bool move= false;

    public bool atack= false;
    public Transform[] waypoints;
    int _currentWaypoint;
    public float maxRange;
    float _speed;
    bool _goingBackwards;
    public float rotSpeed;
    public int life = 100;
    SpriteRenderer srp;

    fueguito firesss;

    void Start()
    {
        jero = FindObjectOfType<jero>();
        srp = GetComponent<SpriteRenderer>();
        posinitial = transform.position;
        _currentWaypoint = 0;
        transform.position = waypoints[_currentWaypoint].position;
        _speed = 5;
        spawnfire = FindObjectOfType<spawnfire>();
        firesss= FindObjectOfType<fueguito>();
    }

    private void Move()
    {
        if (Vector3.Distance(waypoints[_currentWaypoint].position, transform.position) < maxRange)
        {
            if (_currentWaypoint == waypoints.Length - 1)
                _goingBackwards = true;
            else if (_currentWaypoint == 0)
                _goingBackwards = false;

            if (!_goingBackwards)
                _currentWaypoint++;
            else
                _currentWaypoint--;
        }
        transform.position += (waypoints[_currentWaypoint].position - transform.position).normalized * _speed * Time.deltaTime;
    }
          

   
    
    void Update()
    {

        if (atack== true)
        {
            Target();
            Firemove();
            Move();
            Feedback();
            LIFEX();
            
        }

        //Shoot();
        //Rotation();
    }
    
    void Firemove()
    {
        if (fires[0] != null)
        {
            if (activefire0)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[0].transform.position);
                fires[0].transform.position += dirjero.normalized * speedatack * Time.deltaTime;
               
                

            }
        }

        if (fires[1] != null)
        {
            if (activefire1)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[1].transform.position);
                fires[1].transform.position += dirjero.normalized * speedatack * Time.deltaTime;

            }
        }
        if (fires[2] != null)
        {
            if (activefire2)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[2].transform.position);
                fires[2].transform.position += dirjero.normalized * speedatack * Time.deltaTime;

            }
        }
        if (fires[3] != null)
        {
            if (activefire3)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[3].transform.position);
                fires[3].transform.position += dirjero.normalized * speedatack * Time.deltaTime;

            }
        }
        if (fires[4] != null)
        {
            if (activefire4)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[4].transform.position);
                fires[4].transform.position += dirjero.normalized * speedatack * Time.deltaTime;

            }
        }
        if (fires[5] != null)
        {
            if (activefire5)
            {
                stoprotate = false;
                move = true;
                Vector3 dirjero = (jero.transform.position - fires[5].transform.position);
                fires[5].transform.position += dirjero.normalized * speedatack * Time.deltaTime;

            }
        }
        else if (move == false)
        {

            stoprotate = true;
        }
    }

    void Target()
    {

        countshoot += 1 * Time.deltaTime;

        if (countshoot >= 5)
        {
            countshoot = 0;
            countfire++;

        }

        if (countfire == 1 && !activefire0)
        {
           
            activefire0 = true;

        }
        if (countfire == 2 && !activefire1)
        {
           
            activefire1 = true;
        }
        if (countfire == 3 && !activefire2)
        {
           
            activefire2 = true;
        }
        if (countfire == 4 && !activefire3)
        {
            
            activefire3 = true;
        }
        if (countfire == 5 && !activefire4)
        {
            
            activefire4 = true;
        }
        if (countfire == 6 && !activefire5)
        {
            
            activefire5 = true;
        }

        
        
    }
    void LIFEX()
    {
        if (life == 0)
            SceneManager.LoadScene(4);
    }
    bool dmg;
    float countcolor;
    
    float countspeed;

    void Feedback()
    {


        if (dmg == true)
        {
            srp.color = Color.red;
            countcolor += Time.deltaTime;
        }
        if (countcolor >= 0.3f)
        {

            countcolor = 0;
            dmg = false;
        }

        if (countcolor == 0)
            srp.color = Color.white;


        
    }
    spawnfire spawnfire;
    public Transform[] posfires;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!fires[0]&& !fires[1] && !fires[2] && !fires[3] && !fires[4] && !fires[5] && collision.gameObject.layer == 10)
        {
            life -= 20;
            dmg = true;
        }
    }
}
