using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIaloguePlayerScript : MonoBehaviour
{

    public Animator anim;
    public GameObject line7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (line7.activeSelf)
            {
                anim.SetTrigger("Shotgun");
            }
    }
}
