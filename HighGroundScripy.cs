using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighGroundScripy : MonoBehaviour
{
    public GameObject ground;
  

    void OnTriggerEnter2D (Collider2D collision)
        {
      
            ground.gameObject.SetActive(false);       
             
        }
}
