using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class BloddySkins : MonoBehaviour

{


    public GameObject NormalSkinBlood, ShotgunSkinBlood;
    public Transform FollowTarget1, background;
    int SkinAtual = 1;
    bool cham = true;
    public bool Cam1Check = true;
    public CinemachineVirtualCameraBase CM_cam1;



    // Start is called before the first frame update
    void Start()
    {

        NormalSkinBlood.gameObject.SetActive(true);
        ShotgunSkinBlood.gameObject.SetActive(false);
        FollowTarget1 = NormalSkinBlood.transform;
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
           ShotgunSkinBlood.transform.position = new Vector3(NormalSkinBlood.transform.position.x, NormalSkinBlood.transform.position.y, NormalSkinBlood.transform.position.z);
            cham = false;
        }
        else if (Input.GetButtonDown("Fire1") && !cham)
        {
            SkinAtual = 1;
            NormalSkinBlood.transform.position = new Vector3(ShotgunSkinBlood.transform.position.x, ShotgunSkinBlood.transform.position.y, ShotgunSkinBlood.transform.position.z);
            cham = true;
        }

        if (Input.GetButtonDown("Fire1") && Cam1Check)
        {
            Cam1Check = false;
            FollowTarget1 = ShotgunSkinBlood.transform;
            CM_cam1.LookAt = background;
            CM_cam1.Follow = FollowTarget1;
        } 
        else if(Input.GetButtonDown("Fire1") && !Cam1Check)
        {
            Cam1Check = true;
            FollowTarget1 = NormalSkinBlood.transform;
            CM_cam1.LookAt = FollowTarget1;
            CM_cam1.Follow = FollowTarget1;
           
        }
    }

    

        void SkinSwitch()
        { 
            switch(SkinAtual) {
            case 1:

            SkinAtual = 1;

            NormalSkinBlood.gameObject.SetActive(true);
            ShotgunSkinBlood.gameObject.SetActive(false);
            break;

            case 2:


             SkinAtual = 2;

            NormalSkinBlood.gameObject.SetActive(false);
            ShotgunSkinBlood.gameObject.SetActive(true);
            break;
            }
        }
             
}
