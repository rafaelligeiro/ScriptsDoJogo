using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongFadeOut : MonoBehaviour
{
    private AudioSource soudtrackAudioSource;
    private float fadeTime = 3f;
    public GameObject fadeStart;
    public AudioSource OtherSound;

    void Start () {
     soudtrackAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    if(fadeStart.activeSelf)
        {
        StartCoroutine(AudioFade.FadeOut(soudtrackAudioSource, fadeTime));
        StartCoroutine(Disable());
        }

    }


    IEnumerator Disable()
        {
        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);       
        }

}
