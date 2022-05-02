using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetransition : MonoBehaviour
{

    private Animator animation;

    void Start()
    {
        animation = GetComponent<Animator>();
    }


    void OnEnable()
    {
        SceneManager.LoadScene("PAP backup", LoadSceneMode.Single);
        animation.SetTrigger("Start");

    }
}
