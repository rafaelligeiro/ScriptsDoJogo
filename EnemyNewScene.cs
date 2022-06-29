using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNewScene : MonoBehaviour
{
   public float speed;
   public float Distance;
   private bool movingLeft = true;
   public int vida = 1;
   int vidaAtual;
   public ParticleSystem BloodEffect;
   public GameObject playerDetect;

   public Transform groundDetect;

   void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        Flip();
    }

    public void Flip()
        {
           RaycastHit2D GroundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, Distance);
        if(GroundInfo.collider == false) 
        {
            if(movingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingLeft = false;
                } else {
                    transform.eulerAngles = new Vector3(0, -0, 0);
                    movingLeft = true;
                }
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

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
                if(movingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingLeft = false;
                } else {
                    transform.eulerAngles = new Vector3(0, -0, 0);
                    movingLeft = true;
                }
                
            }
        if(collision.CompareTag("Rock"))
         {
                if(movingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingLeft = false;
                } else {
                    transform.eulerAngles = new Vector3(0, -0, 0);
                    movingLeft = true;
                }
                
            }
}
}
