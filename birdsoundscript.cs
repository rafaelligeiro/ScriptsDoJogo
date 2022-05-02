using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdsoundscript : MonoBehaviour
{
    public AudioSource BirdSound;


    void Update()
    {
        StartCoroutine(StopSound());
    }

    IEnumerator StopSound()
        {
            yield return new WaitForSeconds(2f);
            
            BirdSound.volume = 0f;
        }
}
