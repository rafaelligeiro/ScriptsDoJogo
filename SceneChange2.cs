using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange2 : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Input.GetKeyDown("e")){
        SceneManager.LoadScene("NewScenario", LoadSceneMode.Single);
        }
    }
}
