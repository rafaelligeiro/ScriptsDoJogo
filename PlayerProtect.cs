using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProtect : MonoBehaviour
{
    
    public GameObject Shield;
    private Animator anim;
    public Slider staminaBar;
    public GameObject stamina;
    

    void Start()
    {
        Shield.gameObject.SetActive(false);
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("e"))
        {
            ProtectProguessBar.instance.UseStamina(15);
            anim.SetBool("block", true);
            Shield.gameObject.SetActive(true);
        }

        if (Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("Run", true);
                anim.SetBool("block", false);
                Shield.gameObject.SetActive(false);

            }

        if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("Run", true);
                anim.SetBool("block", false);
                Shield.gameObject.SetActive(false);

            }

        if(Input.GetKeyUp("e"))
            {
             anim.SetBool("block", false);
             Shield.gameObject.SetActive(false);
            }

        if(staminaBar.value < 15)
            {
              anim.SetBool("block", false);  
            }

        if (!Shield)
            {
            anim.SetBool("block", false);
            }
    }

   
}
