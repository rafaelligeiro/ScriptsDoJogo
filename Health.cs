using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   public float currentHealth;
   public Animator anim;
   public AudioSource hurtSound;
   

   public void Awake()
    {
        currentHealth = startingHealth;
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
                Destroy(gameObject);
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
}
