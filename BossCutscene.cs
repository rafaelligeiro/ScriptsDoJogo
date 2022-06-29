using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCutscene : MonoBehaviour
{
    
    public GameObject startCutscene;
    public CinemachineVirtualCameraBase CM1;
    public GameObject EnableThing1;
    public GameObject allGameStuff, allGameStuff2;
    public GameObject fire1, fire2, fire3;
    public AudioSource GameAudio, BossAudio;
    private Collider2D thisthing;


    void Start()
        {
            thisthing = GetComponent<Collider2D>();
        }


    void OnTriggerEnter2D (Collider2D HitInfo)
        {
            if(HitInfo.CompareTag("Player"))
            {
            CM1.m_Priority = 10;
            StartCoroutine(startThis());
            allGameStuff.gameObject.SetActive(false);
            StartCoroutine(FireStart());
            GameAudio.Stop();
            BossAudio.Play();
            thisthing.enabled = false;
        }
        } 

    IEnumerator FireStart()
        {
            yield return new WaitForSeconds(3f);

            fire1.gameObject.SetActive(true);
            fire2.gameObject.SetActive(true);
            fire3.gameObject.SetActive(true);
        }

    IEnumerator PlayerGone()
        {
            yield return new WaitForSeconds(1f);

            allGameStuff2.gameObject.SetActive(false);
        }


    IEnumerator startThis()
        {
            yield return new WaitForSeconds(2f);
            EnableThing1.gameObject.SetActive(true);   
        }

}
