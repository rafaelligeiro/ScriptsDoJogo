using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerSkins2 : MonoBehaviour

{


    public GameObject NormalSkin, NormalSkinBlood;
    public GameObject NormalHealth, BloodHealth;
    public GameObject OtherSwitch;
    public Transform FollowTarget1, background;
    public ParticleSystem BloodShit;
    int SkinAtual = 1;
    public bool Cam1Check = true;
    public CinemachineVirtualCameraBase CM_cam1;



    // Start is called before the first frame update
    void Start()
    {
        BloodShit.Stop();
        NormalSkin.gameObject.SetActive(true);
        NormalHealth.gameObject.SetActive(true);
        BloodHealth.gameObject.SetActive(false);
        NormalSkinBlood.gameObject.SetActive(false);
        OtherSwitch.gameObject.SetActive(false);
        FollowTarget1 = NormalSkin.transform;
        CM_cam1.LookAt = FollowTarget1;
        CM_cam1.Follow = FollowTarget1;

    }


    // Update is called once per frame
    void Update()
    { 
    
        StartCoroutine( NormalSkinBloodActive());
    }

      IEnumerator NormalSkinBloodActive()
    {
        if (BloodShit.isPlaying)
        {
            //SkinSwitch();
            BloodShit.Stop();
            NormalSkinBlood.transform.position = new Vector3(NormalSkin.transform.position.x, NormalSkin.transform.position.y, NormalSkin.transform.position.z);
            yield return new WaitForSeconds(0.40f);
            SkinAtual = 2;
            NormalSkin.gameObject.SetActive(false);
            NormalHealth.gameObject.SetActive(false);
            NormalSkinBlood.gameObject.SetActive(true);
            BloodHealth.gameObject.SetActive(true);
            OtherSwitch.gameObject.SetActive(true);
            FollowTarget1 = NormalSkinBlood.transform;
            CM_cam1.LookAt = background;
            CM_cam1.Follow = FollowTarget1;
            Destroy(gameObject);
        }
    }

        void SkinSwitch()
        { 
            switch(SkinAtual) {
            case 1:

            SkinAtual = 1;

            NormalSkin.gameObject.SetActive(true);
            NormalSkinBlood.gameObject.SetActive(false);
            break;

            case 2:


             SkinAtual = 2;

            NormalSkin.gameObject.SetActive(false);
            NormalSkinBlood.gameObject.SetActive(true);
            break;
            }
        }
             
}
