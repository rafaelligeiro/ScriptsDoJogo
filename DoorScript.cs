using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

  public GameObject text;

  void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("Player"))
        {
          text.gameObject.SetActive(true);
        }
    }

    void Update()
        {
            if (Input.GetKeyDown("s") && text.activeSelf)
                    {
                      Application.LoadLevel("NewScenario");
                    }
        }
}
