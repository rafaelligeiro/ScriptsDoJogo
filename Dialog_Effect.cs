using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Dialog_Effect : MonoBehaviour
{
   
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private AudioSource TypingAudio;

    void Start() 
        {
            TypingAudio = GetComponent<AudioSource>();
        }

   public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
   {
       this.uiText = uiText;
       this.textToWrite = textToWrite;
       this.timePerCharacter = timePerCharacter;
       characterIndex = 0;
   }

    private void Update() 
    {
        if (uiText != null) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) 
            {
                TypingAudio.Play();
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

            if (characterIndex >= textToWrite.Length)
            {
                TypingAudio.Stop();
                uiText = null;
                return;
            }


            }
        
        }

    
    }
}
