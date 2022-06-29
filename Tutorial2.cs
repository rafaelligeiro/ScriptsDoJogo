using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
   
   public GameObject PopUp2, enemy;
   public GameObject PlayerBlood;


    void Start()
        {
        PopUp2.gameObject.SetActive(false);
        }


    void Update()
    {
        if (enemy == null)
            {
                PopUp2.gameObject.SetActive(true);
                PlayerBlood.gameObject.SetActive(true);

                StartCoroutine(timeOfPopUp());
            }
    }

    IEnumerator timeOfPopUp()  
        {
            yield return new WaitForSeconds(5f);

        Destroy(gameObject);
        }
}
