using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public int vida = 20;
    public int vidaAtual;
    private Animator anim;
    public ParticleSystem bloodBoss;
    public Slider healthbar;
    
    void Start()
    {
    vidaAtual = vida;
    anim = GetComponent<Animator>();
    }

    public void Update()
        {
          healthbar.value = vidaAtual;
        }

    public void TakeDamage( int _damage)
    {
      vidaAtual = Mathf.Clamp(vidaAtual - _damage, 0, vida);
        if (vidaAtual > 0)
        {
           anim.SetBool("Hurt", true);
           StartCoroutine(StopHurtBug());
           Instantiate(bloodBoss, transform.position, Quaternion.identity);
        } else
            {
               StartCoroutine(Die());
            }
    }

    IEnumerator Die()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


    IEnumerator StopHurtBug()
        {
            yield return new WaitForSeconds(0.2f);

            anim.SetBool("Hurt", false);
            anim.SetBool("Run", true);
        }
}
