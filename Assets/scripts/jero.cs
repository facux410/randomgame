using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class jero : MonoBehaviour
{

    public float life1;//ponerle vida y que reciba daño el chabon // ya ta
    public float speed;
    public float jumpforce;
    public Rigidbody2D rb;
    public SpriteRenderer SpR;

    public GameObject fireatack;// que dispare y vere de hacer un disparo cargado //dispara 

    Canvas text;

    public Animator animator;
    public bool isMoving;
    
    public GameObject AreaJ;

   
    public Enemy enemy; //son todos unos putos ahr, varios enemigos 
    public gamemanager manager;

    public UnityEngine.UI.Image HealthBar;
    
    public GameObject cluck;

   // bool die = false; // nesesito morir //aun no muero

    public wals wals;
    public Vector3 position;
    public wals2 wlss2;
    
    public int countlife;
    bool isJumping;
    public Image alaas;
    public float countalas;
    public bool fly = false;
    public float counttt;
    [Header ("disparos")]
    public shoot shoot;
    public Transform shootspawn;
    public float firerate;
    float nextfire;
    
    public float speedy;


    // me faltan muchas cosas :C // ya falta menos
    public float dir;
    
    bool dmg = false;
    public float countcolor;
    bool minusspeed=false;
    float countspeed;
    bool stun = false;
    float stuncount;
    public float timerest;
    bool mechocaron = false;
    public Text counttonext;
    public int countlife2;

    pointertopoint lookmouse;

    public bool haveshield;

    public int lifeshield;

    public bool lvl2;
    public bool gravity;

    
    


    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
        wals = FindObjectOfType<wals>();
        wlss2 = FindObjectOfType<wals2>();
        position = new Vector3(3, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        lookmouse = FindObjectOfType<pointertopoint>();
        lifeshield = 3;


        


    }

    void Update()
    {
        if(stun==false)
            move();
        Jump();
        Feedback();
        Alas();
        Lifex();
        animator.SetBool("isMoving", isMoving);

        if(rb.gravityScale ==0 && lvl2==false)
            TextC();

        HealthBar.fillAmount = life1 / 100;

        animator.SetBool("isjumping", isJumping);
        alaas.fillAmount = countalas / 100;
        animator.SetBool("fly", fly);

        if (lvl2 == true && rb.gravityScale==0)
        {
            var diry = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2( speed, diry * speedy);



        }
            
        else
            lvl2 = false;
    }


    void move()
    {
        dir = Input.GetAxisRaw("Horizontal");
        var diry = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dir * speed,rb.velocity.y);
        if (rb.gravityScale == 0 && lvl2==false)
        {
            rb.velocity = new Vector2(dir * speed, diry * speedy);
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            isMoving = true;
            SpR.flipX = true;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            SpR.flipX = false;
            
            
           
        }
        else
        {
            isMoving = false;
        }
        


    }
    void Lifex()
    {
        HealthBar.fillAmount = life1 / 100;

        if (life1 <= 0)
            SceneManager.LoadScene(5);
            
    }
    public bool onlyjump;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            rb.AddForce(new Vector2(0, 1) * jumpforce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }

    }
    void TextC()
    {
            counttonext.text = "Sobrevive " + timerest + "segundos";

            if (mechocaron == true)
            {
                timerest += 1;
                mechocaron = false;
            }


            else
                timerest -= Time.deltaTime;

            if (timerest <= 0)
                SceneManager.LoadScene(2);
    }
   

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            SceneManager.LoadScene(5);
            Debug.Log("me mori");
        }
        if (collision.gameObject.layer == 14)
        {
            wals.gameObject.transform.position -= position;
            wlss2.gameObject.transform.position += position;
        }
        
        if (collision.gameObject.layer == 17)
        {
            dmg = true;
            mechocaron = true;
        }
        if(collision.gameObject.layer == 18)
        {
            dmg = true;
            minusspeed=true;
            speed -= 5;
            mechocaron = true;
        }
        if (collision.gameObject.layer == 19)
        {
            dmg = true;
            stun = true;
            mechocaron = true;
        }
        

    }
    void Feedback()
    {
        

        if (dmg == true)
        {
            SpR.color = Color.red;
            countcolor+=Time.deltaTime;
        }
        if(countcolor >= 0.3f)
        {
            
            countcolor = 0;
            dmg = false;
        }

        if (countcolor == 0)
            SpR.color = Color.white;

        if(minusspeed == true)
        {
            countspeed += Time.deltaTime;
        }
        if(countspeed >= 3)
        {
            countspeed = 0;
            
            speed = 10;
        }

        if (stun == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
            stuncount += Time.deltaTime;
        }
        if(stuncount >= 1)
        {
            stun = false;
            stuncount = 0;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
    
    

    public float timetofly;
    private void Alas()
    {
        if(countalas >= 100 && Input.GetKeyDown(KeyCode.Space)  && !haveshield)
        {
            haveshield = true;
            
            lifeshield = 3;
            
            fly = true;
        }
        


        
        if (counttt >= 0.1f)
        {
            counttt+= 0.1f * Time.deltaTime;
            if (counttt >= 0.2)
            {
                countalas = 0;
                counttt = 0;
                fly = false;
            }
        }
        
    }

    
}
