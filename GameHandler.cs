using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Isto;

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Return))
         {
         Application.LoadLevel("Game_Opening");
         }
            
            if(Isto.activeSelf)
                {
                    Canvas.gameObject.SetActive(false);
                }
    }
}
