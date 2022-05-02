using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStraight : MonoBehaviour
{
   public Transform bullet;


   void OnTriggerEnter2D(Collider2D collision)
    {
        bullet.GetComponent<ProjectileEnemy>().DestroyProjectile();
    }
}
