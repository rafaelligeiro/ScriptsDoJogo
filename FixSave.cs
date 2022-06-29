using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSave : MonoBehaviour
{
    public GameObject text;


    void Update()
    {
         if(Input.GetKeyDown("s"))
         {
         Application.LoadLevel("PAP backupTest");
         }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player2"))
            {
                text.gameObject.SetActive(true);
            }
    }
}
