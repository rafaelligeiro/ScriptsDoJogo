using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
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
    public GameObject Tutorial;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
         if (Tutorial == null)
        {
        Move();
        } 

        //Jump
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, CompGround, groundLayer);



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
            animation.SetBool("run", true);
            animation.SetBool("Jump", false);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
            animation.SetBool("run", true);
            animation.SetBool("Jump", false);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         
         if(Input.GetAxis("Horizontal") == 0f)
        {
            animation.SetBool("run", false);
            
        }
      
    }  
}

