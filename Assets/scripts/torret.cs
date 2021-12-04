using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class torret : MonoBehaviour
{
    
    public float spawntime;
    public GameObject spawner;
    public GameObject shoot;
    float timer;
    public Vector3 rott;
    public float speed;
    public Vector3 dir;

    public Transform[] waypoints;
    int _currentWaypoint;
    public float maxRange;
    float _speed;
    bool _goingBackwards;
    public float rotSpeed;
    BOSS bosss;

    void Start()
    {
        _currentWaypoint = 0;
        if(waypoints.Length !=0)
        transform.position = waypoints[_currentWaypoint].position;
        _speed = 5;
        bosss = FindObjectOfType<BOSS>();
    }
    
    private void Move()
    {
        if (waypoints.Length != 0 )
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
    }
    // Update is called once per frame
    private void Awake()
    {
        dir = transform.up;
    }
    void Update()
    {
        transform.RotateAround(spawner.transform.position, rott, speed * Time.deltaTime);

        timer += Time.deltaTime;
        
            Torreta();

        
        Move();

       

    }
    void Torreta()
    {
        

        if (timer >= spawntime)
        {
            Instantiate(shoot,spawner.transform.position,spawner.transform.rotation);
            timer = 0;
            

        }
    }
}
