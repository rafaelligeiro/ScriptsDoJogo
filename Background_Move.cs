using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{



    private float length, startpos;
    public GameObject camera;
    public float efeito;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

        float dist = (GetComponent<Camera>().transform.position.x * efeito);

        
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
