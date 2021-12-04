using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianas : MonoBehaviour
{
    public Transform[] waypoints;
    int _currentWaypoint;
    public float maxRange;
    float _speed;
    bool _goingBackwards;
    public float rotSpeed;
    jero jero;
    SpriteRenderer srp;
    void Start()
    {
        jero = FindObjectOfType<jero>();
        srp = FindObjectOfType<SpriteRenderer>();
        _currentWaypoint = 0;
        transform.position = waypoints[_currentWaypoint].position;
        _speed = 5;
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
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            jero.countalas+=10;
            Destroy(gameObject);
            
        }
    }
}
