using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour
{

    public GameObject Enemy;
   

    // Update is called once per frame
    void Update()
    {
        if(Enemy == null)
            {
                Destroy(gameObject);
            }
    }
}
