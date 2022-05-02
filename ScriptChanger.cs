using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptChanger : MonoBehaviour
{

    public Animator anim;
    bool cham = true;
    [SerializeField] private Image currentBulletBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        this.GetComponent<ShotgunPlayerAttack>().enabled = false;
        this.GetComponent<BloodyShotgun>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && cham)
            {
                anim.SetTrigger("ShotgunAppear");
                anim.SetBool("ShotgunIDLE", true);
                anim.SetBool("Run", false);
                this.GetComponent<PlayerBloodyAttack>().enabled = false;
                this.GetComponent<PlayerBloodyScript>().enabled = false;
                this.GetComponent<BloodyShotgun>().enabled = true;
                cham = false;
            if(currentBulletBar.fillAmount > 0)
                {
                    this.GetComponent<ShotgunPlayerAttack>().enabled = true;
                } else {
                    this.GetComponent<ShotgunPlayerAttack>().enabled = false;
                }
            }
        
        else if(Input.GetKeyDown("g") && cham == false)
            {
                anim.SetBool("ShotgunIDLE", false);
                this.GetComponent<PlayerBloodyAttack>().enabled = true;
                this.GetComponent<PlayerBloodyScript>().enabled = true;
                this.GetComponent<BloodyShotgun>().enabled = false;
                cham = true;
            }


    }
}
