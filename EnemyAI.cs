using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public int vida = 1;
    int vidaAtual;
    public ParticleSystem BloodEffect;
    private Rigidbody2D rig;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float stopping;
    public GameObject projectile;
    public Transform player;
    public float StartTimeBtwShots;
    public float TimeBtwnShots;
    public float retreatDistance;
    public Transform shotpoint;
    private Animator anim;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vidaAtual = vida;
        BloodEffect.Stop();
        rig = this.GetComponent<Rigidbody2D>();
        TimeBtwnShots = StartTimeBtwShots;
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        movement = direction;
        Vector2 force = direction * moveSpeed * Time.deltaTime;

        rig.AddForce(force);
        
        if(force.x > 0f)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
            } else if (force.x < 0f)
                {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
     
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        if(Vector2.Distance(transform.position, player.position) > stopping)
     {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        anim.SetBool("Walk", true);
        anim.SetBool("skeletonAttackPose", false);
        TimeBtwnShots = 0.5f;

     } else if(Vector2.Distance(transform.position, player.position) < stopping && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
           transform.position = this.transform.position;
           anim.SetBool("skeletonAttackPose", true);
           anim.SetBool("Walk", false);
           StartTimeBtwShots = 1f;
           TimeBtwnShots -= Time.deltaTime; 

        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
            TimeBtwnShots = 1f;
            }
       

        if(TimeBtwnShots <= 0 && Vector2.Distance(transform.position, player.position) < stopping && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
                Instantiate(projectile, shotpoint.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
                anim.SetBool("skeletonAttackPose", true);
                anim.SetBool("Walk", false);
                TimeBtwnShots = 1f;

            } else if(TimeBtwnShots <= 0 && Vector2.Distance(transform.position, player.position) > stopping && Vector2.Distance(transform.position, player.position) > retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                    anim.SetBool("Walk", true);
                    anim.SetBool("skeletonAttackPose", false);
                    TimeBtwnShots = 1f;
                }
    }

    

    public void TakeDamage( int dano)
    {
        vidaAtual -= dano;

        if(vidaAtual <= 0)
        {
            BloodEffect.Play();
            Instantiate(BloodEffect, transform.position, Quaternion.identity);
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
