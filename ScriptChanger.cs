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
        this.GetComponent<PlayerProtect>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && cham)
            {
                anim.SetTrigger("ShotgunAppear");
                anim.SetBool("ShotgunIDLE", true);
                this.GetComponent<PlayerBloodyScript>().enabled = false;
                this.GetComponent<PlayerBloodyAttack>().enabled = false;
                this.GetComponent<BloodyShotgun>().enabled = true;
                cham = false;
            if(currentBulletBar.fillAmount > 0)
                {
                    this.GetComponent<ShotgunPlayerAttack>().enabled = true;
                }
            }
        
        else if(Input.GetButtonDown("Fire1") && cham == false)
            {
                anim.SetBool("ShotgunIDLE", false);
                anim.SetBool("ShotgunRun", false);
                anim.SetBool("Run", true);
                this.GetComponent<PlayerBloodyScript>().enabled = true;
                this.GetComponent<PlayerBloodyAttack>().enabled = true;
                this.GetComponent<BloodyShotgun>().enabled = false;
                cham = true;
            }

    }
}
