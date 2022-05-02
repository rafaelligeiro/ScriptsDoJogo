using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
   [SerializeField] private float healthValue;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            {
                collision.GetComponent<Health>().AddHealth(healthValue);
                Destroy(gameObject);
            }
    }
}
