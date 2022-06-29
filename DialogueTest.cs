using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DialogueTest : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject BloodPlayer;
    public GameObject BloodPlayerDialogue;
    public GameObject Script;
    public Transform FollowTarget1;
    public CinemachineVirtualCameraBase CM_cam1, CM_cam2;
    public GameObject NPCSprite;
    public GameObject FinalDialogue;
    public GameObject BulletVisual;
    public GameObject piupiu;
    public GameObject GameSong;
    public GameObject GameSound;




    // Start is called before the first frame update
    void Start()
    {
        GameSong.GetComponent<AudioSource>();
        GameSound.GetComponent<AudioSource>();
       BloodPlayer.GetComponent<ScriptChanger>().enabled = false;
        dialogue.gameObject.SetActive(false);
        BloodPlayerDialogue.gameObject.SetActive(false);
        FollowTarget1 = BloodPlayer.transform;
        CM_cam1.LookAt = FollowTarget1;
        BulletVisual.gameObject.SetActive(false);
        piupiu.gameObject.SetActive(false);
        GameSound.gameObject.SetActive(false);
        BloodPlayer.gameObject.SetActive(true);
    }
    void Update()
        {
            if(GameSong.activeSelf)
                {
                    GameSound.gameObject.SetActive(false);
                } else{
                    GameSound.gameObject.SetActive(true);
                }

                
            if (dialogue.activeSelf)
                 {
                 NPCSprite.gameObject.SetActive(false);
                 if(piupiu != null)
                 {
                    piupiu.gameObject.SetActive(true);
                 }
                 }
        BloodPlayerDialogue.transform.position = new Vector3(BloodPlayer.transform.position.x, BloodPlayer.transform.position.y, BloodPlayer.transform.position.z);

        if (FinalDialogue == null)
            {
                NPCSprite.gameObject.SetActive(true);
                BloodPlayer.gameObject.SetActive(true);
                BloodPlayerDialogue.gameObject.SetActive(false);
                CM_cam2.Priority = 0;
                Destroy(dialogue);
                BloodPlayer.GetComponent<ScriptChanger>().enabled = true;
                BulletVisual.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player")) 
                {
                  BloodPlayerDialogue.gameObject.SetActive(true);
                  dialogue.gameObject.SetActive(true);
                  FollowTarget1 = BloodPlayerDialogue.transform;
                  CM_cam2.LookAt = FollowTarget1;
                  CM_cam2.Priority = 10;
                  BloodPlayer.gameObject.SetActive(false);
                  Script.gameObject.SetActive(false);
                }
        }

    
}
