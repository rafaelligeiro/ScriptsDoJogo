using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeathScreenScript1 : MonoBehaviour
{
    
    public CinemachineVirtualCamera vcam;





    void Start()
    {
        vcam.m_Lens.FieldOfView = 20;
    }
}
