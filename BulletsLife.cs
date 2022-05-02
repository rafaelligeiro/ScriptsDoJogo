using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsLife : MonoBehaviour
{
   [SerializeField] private float startingBullets;
   public float currentBullets;
   public GameObject player;

   public void Awake()
    {
        currentBullets = startingBullets;
    }

    public void TakeBullet(float _damage)
    {
        currentBullets = Mathf.Clamp(currentBullets - _damage, 0, startingBullets);
        if (currentBullets > 0)
        {
            Debug.Log("1 bullet fire!");
        } else
            {
                player.GetComponent<ShotgunPlayerAttack>().enabled = false;
            }

    }

    public void AddBullet(float _value)
    {
    currentBullets = Mathf.Clamp(currentBullets + _value, 0, startingBullets);
    }


}
   
