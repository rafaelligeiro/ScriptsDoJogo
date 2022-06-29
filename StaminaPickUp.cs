using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickUp : MonoBehaviour
{
   [SerializeField] private int StaminaValue = 25;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                
                Debug.Log("Stamina Gain");
                ProtectProguessBar.instance.AddStamina(StaminaValue);
                Destroy(gameObject);
            }   
        }
}
