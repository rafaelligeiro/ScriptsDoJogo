using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   public float currentHealth;
   public Animator anim;
   public AudioSource hurtSound;
   public AudioSource goreSound;
   public AudioSource DeadSound;
   public GameObject Canvas;
   public GameObject CMBlendList;
   public EnemyAI enemy;
   public GameObject Player;
   private Collider2D Mine;
   public AudioListener cameraMain;


   public void Start()
    {
        Mine = GetComponent<Collider2D>();
    }
   public void Awake()
    {
        if(Player != null)
        {
        Player.gameObject.SetActive(true);    
        } else{
            return;
        }
        currentHealth = startingHealth;
        if(Canvas != null)
        {
            Canvas.gameObject.SetActive(false);
        } else{
            return;
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetBool("Player-hurt", true);
            hurtSound.Play();
            StartCoroutine(hurttime());
        } else
            {
                StartCoroutine(Deathfix());
                StartCoroutine(DeathScreen());
                CMBlendList.gameObject.SetActive(true);
            }

    }

    public void TakeDamage3(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetBool("Player-hurt", true);
            hurtSound.Play();
            StartCoroutine(hurttime());
        } else
            {
                //Mine.enabled = false;
                StartCoroutine(Deathfix());
                StartCoroutine(DeathScreen());
                CMBlendList.gameObject.SetActive(true);
                goreSound.Play();
                DeadSound.Play();
                this.GetComponent<PlayerBloodyAttack>().enabled = false;
                this.GetComponent<PlayerBloodyScript>().enabled = false;
                this.GetComponent<BloodyShotgun>().enabled = false;
                this.GetComponent<ShotgunBloodyScript>().enabled = false;
                enemy.GetComponent<EnemyAI>().enabled = false;
            }

    }


    public void TakeDamage2(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetBool("Player-hurt", true);
            hurtSound.Play();
            StartCoroutine(hurttime());
        } else
            {
                //StartCoroutine(Death2());
                anim.SetTrigger("Death2");
                StartCoroutine(DeathScreen());
                CMBlendList.gameObject.SetActive(true);
                goreSound.Play();
                DeadSound.Play();
            }

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    
    IEnumerator hurttime()
        {
            yield return new WaitForSeconds(0.5f);
            hurtSound.Stop();
            anim.SetBool("Player-hurt", false);
        }


        IEnumerator Deathfix()  
            {
                yield return new WaitForSeconds(1f);
                anim.SetTrigger("Death");
            }

        /*IEnumerator Death2()
            {
                yield return new WaitForSeconds(1f);
                anim.SetTrigger("Death2");
            }*/

    IEnumerator DeathScreen()
        {
        yield return new WaitForSeconds(1.5f);
        cameraMain.GetComponent<AudioListener>().enabled = false;
         Canvas.gameObject.SetActive(true);
        }
}
