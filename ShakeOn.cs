using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeOn : MonoBehaviour
{
   private void Start()
    {
        CameraShake.Instance.ShakeCamera(0.1f, .1f);
    }


}
