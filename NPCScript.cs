using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public Animator anim;
    public GameObject line2, line7;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(line2.activeSelf)
            {
                anim.SetTrigger("LookUp");
            }

        if(line7.activeSelf)
            {
               anim.SetTrigger("AndleShotgun"); 
            }
    }
}
