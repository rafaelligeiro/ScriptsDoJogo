using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherGroundCHeck : MonoBehaviour
{

    public GameObject ground;
    void Start()
    {
      ground.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D (Collider2D collision)
        {
      
            ground.gameObject.SetActive(true);    
             
        }

 


}
