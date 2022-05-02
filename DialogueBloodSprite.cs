using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBloodSprite : MonoBehaviour
{

    public GameObject bloodPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        bloodPlayer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
