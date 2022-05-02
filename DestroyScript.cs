using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    public GameObject piupiu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }


    IEnumerator Destroy()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            Destroy(piupiu);
        }
}
