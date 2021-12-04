using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool activateMove;
    public Animator animator;
    public bool EnemyIsMoving;
    public GameObject areaenemy;
    public bool atackenemy;
    public float countenemy;
    public SpriteRenderer spritE;
    public int lifE;
    public bool die;
    public GameObject enemy;
    public jero hero;
    public float timerDie;



    private void Awake()
    {
        hero = FindObjectOfType<jero>();
        speed = 1.5f;
    }
    void anime()
    {
        animator.SetBool("EnemyIsMoving", EnemyIsMoving);
        animator.SetBool("atackenemy", atackenemy);
        animator.SetBool("die",die );
    }

    void Update()
    {
        anime();
        count();
        life();


        if (activateMove)
        {
            Move();
        }
    }
    

    void Move()
    {
        EnemyIsMoving = true;
        if (EnemyIsMoving)
        {
            transform.position += (hero.transform.position - transform.position).normalized * speed * Time.deltaTime;

        }
        
    }
    void count()
    {
        if (lifE <= 0)
        {
            timerDie += Time.deltaTime;
        }
        if(timerDie>1.2f)
        {
            Destroy(gameObject);
        }
    }
    void life()
    {
        if (lifE <= 0)
        {
            die = true;
        }
        else
        {
            die = false;
        }
        if (lifE <= 0)
        {
            atackenemy = false;
            EnemyIsMoving = false;
            activateMove = false;
            
        }
    }
}

