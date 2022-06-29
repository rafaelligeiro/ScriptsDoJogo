using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class PlayerBloodyAttackNewScene : MonoBehaviour
{


    private Animator animation;
    public Transform attackPoint;
	public float attackRange = 1f;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int DanoAtaque = 1;
    public AudioSource swordSound, swordSound2, bloodSound;
    public Vector3 attackOffset;
    public float Force;


    public event EventHandler OnKeyPressed;    

    // Start is called before the first frame update
    void Start()
    {

        animation = GetComponent<Animator>();
        OnKeyPressed += Attack_OnKeyPressed;
        swordSound.Stop();
        

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<ShotgunPlayerAttack>().enabled = false;
        
         if (Input.GetMouseButton(0))
        {
            swordSound.Play();
            animation.SetTrigger("Attack");
            OnKeyPressed?.Invoke(this, EventArgs.Empty);
        }
     

         if (Input.GetMouseButton(0) && Input.GetKey("w"))
        {
            swordSound2.Play();
            animation.SetTrigger("Attack2");
            OnKeyPressed?.Invoke(this, EventArgs.Empty);
        }
    }



        private void Attack_OnKeyPressed(object sender, EventArgs e)
         {
    
                Collider2D hitEnemies = Physics2D.OverlapCircle(attackPoint.position, AttackRange, EnemyLayers);

                if (hitEnemies != null)
	    	{
		    	bloodSound.Play();
                hitEnemies.GetComponent<EnemyNewScene>().TakeDamage(DanoAtaque);
      		}


         }

     void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
