using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCutscene : MonoBehaviour
{

    public GameObject Explosion;
    public AudioSource ExplosionEffect;

    void Start()
      {
        ExplosionEffect.Play();
      }
    void Update()
    {
        if(Explosion == true)
            {
              Shake2.Instance.ShakeCamera2(5f, 2f);
            }
    }
}
