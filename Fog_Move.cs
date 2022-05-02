using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class Fog_Move : MonoBehaviour
{

    private Rigidbody2D rig;
    public GameObject camera;
    private float length, startpos;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x);
        transform.Translate(0.5f * Time.deltaTime, 0, 0);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
