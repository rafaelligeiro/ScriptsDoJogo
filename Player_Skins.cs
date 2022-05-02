using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Player_Skins : MonoBehaviour

{


    public GameObject NormalSkin, ShotgunSkin, NormalSkinBlood, BloodySkins;
    public ParticleSystem BloodShit;
    public Transform FollowTarget1;
    int SkinAtual = 1;
    bool cham = true;
    public bool Cam1Check = true;
    public CinemachineVirtualCameraBase CM_cam1;



    // Start is called before the first frame update
    void Start()
    {

        NormalSkin.gameObject.SetActive(true);
        ShotgunSkin.gameObject.SetActive(false);
        NormalSkinBlood.gameObject.SetActive(false);
        BloodySkins.gameObject.SetActive(false);
        FollowTarget1 = NormalSkin.transform;
        CM_cam1.LookAt = FollowTarget1;
        CM_cam1.Follow = FollowTarget1;

    }


    // Update is called once per frame
    void Update()
    { 
           SkinSwitch();
       
       if (Input.GetButtonDown("Fire1") && cham)
        {
            SkinAtual = 2;
           ShotgunSkin.transform.position = new Vector3(NormalSkin.transform.position.x, NormalSkin.transform.position.y, NormalSkin.transform.position.z);
            cham = false;
        }
        else if (Input.GetButtonDown("Fire1") && !cham)
        {
            SkinAtual = 1;
            NormalSkin.transform.position = new Vector3(ShotgunSkin.transform.position.x, ShotgunSkin.transform.position.y, ShotgunSkin.transform.position.z);
            cham = true;
        }

        if (Input.GetButtonDown("Fire1") && Cam1Check)
        {
            Cam1Check = false;
            FollowTarget1 = ShotgunSkin.transform;
            CM_cam1.LookAt = FollowTarget1;
            CM_cam1.Follow = FollowTarget1;
        } 
        else if(Input.GetButtonDown("Fire1") && !Cam1Check)
        {
            Cam1Check = true;
            FollowTarget1 = NormalSkin.transform;
            CM_cam1.LookAt = FollowTarget1;
            CM_cam1.Follow = FollowTarget1;
           
        }

        StartCoroutine( NormalSkinBloodActive());
    }

      IEnumerator NormalSkinBloodActive()
    {
        if (BloodShit.isPlaying)
        {
            BloodShit.Stop();
            yield return new WaitForSeconds(0.30f);
            NormalSkinBlood.gameObject.SetActive(true);
            BloodySkins.gameObject.SetActive(true);
            NormalSkinBlood.transform.position = new Vector3(NormalSkin.transform.position.x, NormalSkin.transform.position.y, NormalSkin.transform.position.z);
            NormalSkin.gameObject.SetActive(false);
            FollowTarget1 = NormalSkinBlood.transform;
            CM_cam1.LookAt = FollowTarget1;
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
            ShotgunSkin.gameObject.SetActive(false);
            cham = true;
            break;

            case 2:


             SkinAtual = 2;

            NormalSkin.gameObject.SetActive(false);
            ShotgunSkin.gameObject.SetActive(true);
            cham = false;
            break;
            }
        }
             
}
