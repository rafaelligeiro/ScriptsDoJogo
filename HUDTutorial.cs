using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDTutorial : MonoBehaviour
{


    public GameObject Line1, Line2;
    public GameObject Arrow1, Arrow2;
    public GameObject tutorial1, turorial2;
    public bool switchs = true;
    public GameObject canvasForThis;
    public PlayerProtect playerProtectScript1, playerProtectScript2;
    public GameObject player;


    void Start()
    {
        Line1.gameObject.SetActive(true);
        Line2.gameObject.SetActive(false);
        Arrow1.gameObject.SetActive(true);
        Arrow2.gameObject.SetActive(false);
        tutorial1.gameObject.SetActive(false);
        turorial2.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        switchs = true;
        playerProtectScript1.GetComponent<PlayerProtect>().enabled = false;
        playerProtectScript2.GetComponent<PlayerProtect>().enabled = false;

    }

    void Update()
    {
        if(Input.GetMouseButton(0) && switchs)
            {
            Line1.gameObject.SetActive(false);
            Line2.gameObject.SetActive(true);
            Arrow1.gameObject.SetActive(false);
            Arrow2.gameObject.SetActive(true);
            StartCoroutine(ForSwitchs());
            }
        
        if(!switchs && Input.GetMouseButton(0))
            {
                StartCoroutine(DestroyThis());
            }



        IEnumerator DestroyThis()
        {
            yield return new WaitForSeconds(1f);
            tutorial1.gameObject.SetActive(true);
            turorial2.gameObject.SetActive(true);
            player.gameObject.SetActive(true);
            Destroy(canvasForThis);
            playerProtectScript1.GetComponent<PlayerProtect>().enabled = true;
            playerProtectScript2.GetComponent<PlayerProtect>().enabled = true;
        }

    IEnumerator ForSwitchs()
        {
            yield return new WaitForSeconds(1f);
            switchs = false;

        }
    }
}
