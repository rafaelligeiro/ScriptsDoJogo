using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrapScript : MonoBehaviour
{

   [SerializeField] private float damageAmount = 3f;


    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
                Debug.Log("Playerhit");
                collision.GetComponent<Health>().TakeDamage2(damageAmount);
            }
}

}
