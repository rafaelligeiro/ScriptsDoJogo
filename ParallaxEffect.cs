using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float Parallaxeffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float distance = (cam.transform.position.x * Parallaxeffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
