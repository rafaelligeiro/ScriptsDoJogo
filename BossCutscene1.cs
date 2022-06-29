using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutscene1 : MonoBehaviour
{

    public Transform SpotToGo;
    public float moveSpeed = 5f;
    private Vector2 movement;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(this != null)
        {
        Vector3 direction = SpotToGo.position - transform.position;
        movement = direction;
        Vector2 force = direction * moveSpeed * Time.deltaTime;
        }
    
    transform.position = Vector2.MoveTowards(transform.position, SpotToGo.position, moveSpeed * Time.deltaTime);

    }
}
