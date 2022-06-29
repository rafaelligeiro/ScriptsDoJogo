using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player1Attack : MonoBehaviour
{


    private Animator animation;
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int DanoAtaque = 1;
    public AudioSource hitSound, Bloodsound;
    public ParticleSystem bloodEffect;



    public event EventHandler OnKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        OnKeyPressed += Attack_OnKeyPressed;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
        animation.SetTrigger("Attack_1");
        hitSound.Play();
        OnKeyPressed?.Invoke(this, EventArgs.Empty);
        }

    }

    private void Attack_OnKeyPressed(object sender, EventArgs e)
    {
   Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, EnemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Bloodsound.Play();
            bloodEffect.Play();
            enemy.GetComponent<EnemyAI>().TakeDamage(DanoAtaque);
        }
 
    }

     void OnDrawGizmosSelected()
      {
        

          Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
      }


}


