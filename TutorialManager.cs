using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
   public GameObject Game, FirstPopUp;

    void Start()
        {
            FirstPopUp.gameObject.SetActive(true);
            Game.gameObject.SetActive(false);
        }


   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstPopUp.gameObject.SetActive(false);
            Game.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    } 
}

