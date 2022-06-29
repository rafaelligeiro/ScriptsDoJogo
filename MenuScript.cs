using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject background2;
    void Start()
    {
        background2.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            {
            background2.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            }
    }
}
