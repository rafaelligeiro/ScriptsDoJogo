using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : MonoBehaviour
{
   
    public float speed;
    private Animator anim;
    private Transform player;
    private Vector2 movement;
    private Rigidbody2D rig;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        movement = direction;
        Vector2 force = direction * speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
        rig.AddForce(force);
        
        if(force.x > 0f)
            {
                transform.eulerAngles = new Vector3(0f, 0, 0f);
            } else if (force.x < 0f)
                {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                }
    }
}
