using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3 : MonoBehaviour
{

    public GameObject line1, line2;
    public GameObject Spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        line1.gameObject.SetActive(true);
        line2.gameObject.SetActive(false);
        Spawner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g"))
            {
                line1.gameObject.SetActive(false);
                line2.gameObject.SetActive(true);
            }

        if(Input.GetMouseButtonDown(0))
            {
                Spawner.gameObject.SetActive(true);
                Destroy(gameObject);
            }
    }
}
