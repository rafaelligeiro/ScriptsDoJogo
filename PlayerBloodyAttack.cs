using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class PlayerBloodyAttack : MonoBehaviour
{


    private Animator animation;
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int DanoAtaque = 1;
    public GameObject PlayerSkins, NormalSkinBlood;
    public AudioSource swordSound, swordSound2, bloodSound;


    public event EventHandler OnKeyPressed;    

    // Start is called before the first frame update
    void Start()
    {

        animation = GetComponent<Animator>();
        OnKeyPressed += Attack_OnKeyPressed;
        NormalSkinBlood.gameObject.SetActive(false);
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

       

        if (PlayerSkins == null)
        {
            NormalSkinBlood.gameObject.SetActive(true);
        }
    }



        private void Attack_OnKeyPressed(object sender, EventArgs e)
         {
    
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, EnemyLayers);

                  foreach(Collider2D enemy in hitEnemies)
                {
                  bloodSound.Play();
                  enemy.GetComponent<EnemyAI>().TakeDamage(DanoAtaque);


                  }
         }

    

     void OnDrawGizmosSelected()
      {
        

          Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
      }
}