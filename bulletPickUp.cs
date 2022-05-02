using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPickUp : MonoBehaviour
{
    [SerializeField] private float BulletValue;
    public GameObject bullet;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                
                Debug.Log("One bullet Gain");
                player.GetComponent<ShotgunPlayerAttack>().enabled = true;
                bullet.GetComponent<BulletsLife>().AddBullet(BulletValue);
                Destroy(gameObject);
            }   
        }
}
