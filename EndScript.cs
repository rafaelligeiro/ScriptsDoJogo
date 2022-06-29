using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    public GameObject Canvas, text;

   void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
                Canvas.gameObject.SetActive(true);
                StartCoroutine(textAppear());
            }
    }

    IEnumerator textAppear()
        {
            yield return new WaitForSeconds(1f);

            text.gameObject.SetActive(true);
        }
}
