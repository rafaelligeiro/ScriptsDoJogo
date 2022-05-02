using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCutscene : MonoBehaviour
{
    
    public GameObject startCutscene;
    public CinemachineVirtualCameraBase CM1;
    public Transform followthis;
    public GameObject tree;




    void OnTriggerEnter2D (Collider2D HitInfo)
        {
            followthis = tree.transform;
            CM1.LookAt = followthis;
            CM1.Follow = followthis;
        }
}
