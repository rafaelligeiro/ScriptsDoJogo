using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileEnemy : MonoBehaviour
{
   public float speed;
   public Transform player;
   private Vector2 target;
   [SerializeField] private float damageAmount;
   public ParticleSystem BloodPlayer;
   public GameObject shield;
   public GameObject BackDamage;
   public Rigidbody2D rb;
   public float Force;
   



   void Start()
   {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       target = new Vector2(player.position.x, player.position.y);
   }

   void Update()
   {
       //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        rb.velocity = transform.right * speed;

       if(transform.position.x == target.x)
        {
            DestroyProjectile();
        }

        if(transform.position.y == target.x)
            {
              this.gameObject.SetActive(false);  
            }
   }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
                Rigidbody2D Player = collision.GetComponent<Rigidbody2D>();
                if(Player != null)  
                {
                    Vector2 difference = Player.transform.position - transform.position;
                    difference = difference.normalized * Force;
                    Player.AddForce(difference, ForceMode2D.Impulse);
                }
                DestroyProjectile();
                Debug.Log("Playerhit");
                collision.GetComponent<Health>().TakeDamage(damageAmount);       
        }

        if (collision.CompareTag("Shield"))
            {
                DestroyProjectile();
            }
    }


    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
   

}
