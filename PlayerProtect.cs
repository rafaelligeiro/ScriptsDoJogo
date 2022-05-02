using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProtect : MonoBehaviour
{
    
    public GameObject Shield;
    private Animator anim;
    public Slider staminaBar;
    

    void Start()
    {
        Shield.gameObject.SetActive(false);
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("e"))
        {
            ProtectProguessBar.instance.UseStamina(1f);
            anim.SetBool("block", true);
            Shield.gameObject.SetActive(true);
        } else {
            anim.SetBool("block", false);
            Shield.gameObject.SetActive(false);
        }
        
        if(staminaBar.value == 0)
            {
              anim.SetBool("block", false);  
            }

        if (!Shield)
            {
            anim.SetBool("block", false);
            }
    }


   
}
