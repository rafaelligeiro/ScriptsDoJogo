using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandle : MonoBehaviour
{
    public AudioSource GameAudio, BossAudio;

    public void Update()
        {
            GameAudio.Stop();
            BossAudio.Play();
        }
}
