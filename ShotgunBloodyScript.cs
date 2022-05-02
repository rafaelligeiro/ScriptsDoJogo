using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotgunBloodyScript : MonoBehaviour
{


    private Rigidbody2D rig;
    public LayerMask groundLayer;
    public float speed;
    public bool OnGround = false;
    public float CompGround = 1.2f;
    public float HowMuchJump = 10f;
    private Animator anim;
    public float gravity = 2;
    public float fallMultiplier = 10f;
    public float linearDrag = 4f;
    public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Move();

    //DIZER COMO DETECTAR O CHÃO
    OnGround = Physics2D.Raycast(transform.position, Vector2.down, CompGround, groundLayer);

    if (Input.GetAxis("Horizontal") == 0f)
    {
        anim.SetBool("ShotgunIDLE", true);
    }
  
    if (Input.GetAxis("Horizontal") > 0f)
    {
        anim.SetBool("ShotgunIDLE", false);
    }
    
    if (Input.GetAxis("Horizontal") < 0f)
    {
        anim.SetBool("ShotgunIDLE", false);
    }

    if (Input.GetButtonDown("Jump") && OnGround)
    {
        Jump();
        anim.SetBool("Shotgun_run", false);
    }

    if (!OnGround)
    {
         anim.SetBool("Shotgun_jump", true);
    }
    else 
    {
        anim.SetBool("Shotgun_jump", false);
    }

    GravityScale();

    }

    void Jump()
    {
        rig.velocity = new Vector2(rig.velocity.x, 0);  
        rig.AddForce( Vector2.up * HowMuchJump, ForceMode2D.Impulse);

    }

    private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * CompGround);
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

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    

       if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Shotgun_run", true);
           anim.SetBool("Shotgun_jump", false);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Shotgun_run", true);
            anim.SetBool("Shotgun_jump", false);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         
         if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Shotgun_run", false);
            
        }
      
    }
}
