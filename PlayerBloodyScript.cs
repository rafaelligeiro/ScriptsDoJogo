using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerBloodyScript : MonoBehaviour
{


    public float speed;
    private Rigidbody2D rig;
    public LayerMask groundLayer;
    public bool OnGround = false;
    public float CompGround = 1.2f;
    public float HowMuchJump = 15f;
    private Animator animation;
    public float gravity = 2;
    public float fallMultiplier = 10f;
    public float linearDrag = 4f;
    public Vector2 direction;
    public GameObject otherPlayer;
    public event EventHandler OnKeyPressed;
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int DanoAtaque = 1;
    public GameObject Shield;
    public AudioSource runningSound;
    public bool walking;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>(); 
       // OnKeyPressed += Attack_OnKeyPressed;
    }



    // Update is called once per frame
    void Update()
    {
   
    

        if (otherPlayer == null)
            {
                this.gameObject.SetActive(true);

            }

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Move();

    
        if (Input.GetButtonDown("Jump") && OnGround)
        {
            Jump();           
        } 

          if (!OnGround)
        {
            animation.SetBool("Jump", true);
        }
        else
        {
            animation.SetBool("Jump", false);
        }

     

         if (Input.GetAxis("Horizontal") > 0f && !OnGround)
       {
           speed = 8f;
           transform.eulerAngles = new Vector3(0f,0f,0f);
       }
      
       if (Input.GetAxis("Horizontal") < 0f && !OnGround)
       {
           speed = 8f;
           transform.eulerAngles = new Vector3(0f,180f,0f);
       }
      
        if (Input.GetAxis("Horizontal") > 0f && OnGround)
       {
           speed = 5f;
           transform.eulerAngles = new Vector3(0f,0f,0f);
       }

        if (Input.GetAxis("Horizontal") < 0f && OnGround)
       {
           speed = 5f;
           transform.eulerAngles = new Vector3(0f,180f,0f);
       }

        GravityScale();

        OnGroundMethod();

        AirAttack();


    }





   public void OnGroundMethod()
         {
            OnGround = Physics2D.Raycast(transform.position, Vector2.down, CompGround, groundLayer);
         }

    public void AirAttack()
        {
            if(!OnGround && Input.GetMouseButton(0))
                {
                animation.SetBool("Jump", false);   
                animation.SetTrigger("Attack3");
                OnKeyPressed?.Invoke(this, EventArgs.Empty);
            } else if (OnGround)   
                {
                animation.ResetTrigger("Attack3");
                }
        }

    void GravityScale()
    {

        bool changingDirections = (direction.x > 0 && rig.velocity.x < 0) || (direction.x < 0 && rig.velocity.x > 0);

        if (OnGround)
        {
        if (Mathf.Abs(direction.x) < 0.4f || changingDirections) 
        {
            rig.drag = linearDrag;
        }
        else 
        {
            rig.drag = 0f;
        }
         rig.gravityScale = 0;
      }
        else
        {
            rig.gravityScale = gravity;
            rig.drag = linearDrag * 0.15f;
            if (rig.velocity.y < 0f)
            {
                rig.gravityScale = gravity * fallMultiplier;
            }
            else if (rig.velocity.y > 0f && !Input.GetButton("Jump"))
            {
                rig.gravityScale = gravity * (fallMultiplier / 2);

            }

            
            
        }
            
        
    }


    void Jump()
    {
      rig.velocity = new Vector2(rig.velocity.x, 0);  
      rig.AddForce( Vector2.up * HowMuchJump, ForceMode2D.Impulse);
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * CompGround);
    }


   void Move()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;


       if(Input.GetAxis("Horizontal") > 0f)
        {
            animation.SetBool("Run", true);
            animation.SetBool("Jump", false);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
            animation.SetBool("Run", true);
            animation.SetBool("Jump", false);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         
         if(Input.GetAxis("Horizontal") == 0f)
        {
            animation.SetBool("Run", false);
            
        }

        if(Input.GetKeyDown("d") || Input.GetKeyDown("a"))
            {
                runningSound.Play();
            }
        
        if(Input.GetKeyUp("d") || Input.GetKeyUp("a"))
            {
               runningSound.Stop();
            }
        
        if(Input.GetKeyDown("d") && Input.GetKeyDown("a"))
            {
                runningSound.Play();
            }
      
    }

  
}

