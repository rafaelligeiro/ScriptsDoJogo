using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneStop : MonoBehaviour
{
    
    public ShakeCutscene shakeStop;
    public GameObject Explosion;
    public CinemachineVirtualCameraBase CM_cam2;
    public GameObject player;
    private Transform Player;
    public GameObject BOSS;
    public GameObject BOSSsprite;
   

   void Start()
    {
        Player = player.transform;
    }


    void Update()   
    {
        if(Explosion.activeSelf)
            {
                StartCoroutine(StopShake());
            }
    }


    IEnumerator StopShake()
        {
            yield return new WaitForSeconds(2f);

            shakeStop.GetComponent<ShakeCutscene>().enabled = false;

            StartCoroutine(CameraStart());

            player.gameObject.SetActive(true);
            //Instantiate(player,new Vector3 (41, -2, -13), Quaternion.identity);
        }


    IEnumerator CameraStart()
        {
            yield return new WaitForSeconds(1f);
        
        CM_cam2.Follow = Player;
        CM_cam2.LookAt = Player;
        CM_cam2.m_Priority = 10;
        BOSS.gameObject.SetActive(true);
        BOSSsprite.gameObject.SetActive(false);

        }
}
