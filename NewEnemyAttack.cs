using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyAttack : MonoBehaviour
{
    
   public float Force;
   [SerializeField] private float damageAmount = 1.5f;


    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
                Debug.Log("Playerhit");
                Rigidbody2D Player = collision.GetComponent<Rigidbody2D>(); 
                Vector2 difference = Player.transform.position - transform.position;
                difference = difference.normalized * Force;
                Player.AddForce(difference, ForceMode2D.Impulse);
                collision.GetComponent<Health>().TakeDamage(damageAmount);
}

    }
}
