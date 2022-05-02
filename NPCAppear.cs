using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAppear : MonoBehaviour
{
    public GameObject NPC;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NPC.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D colisao)
        {
             if(colisao.CompareTag("Player"))
            {
                NPC.gameObject.SetActive(true);
                Destroy(gameObject);     
        }
        }
}
