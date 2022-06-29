using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    SaveGame PlayerPosData;
    public AudioListener cameraMain;
    [SerializeField] private GameObject canvas;
    public bool canvasOn = false;

    void Start()
        {
          PlayerPosData = FindObjectOfType<SaveGame>();
        }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && canvasOn == false)
        {
            canvas.gameObject.SetActive(true);
            canvasOn = true;
        } else if(Input.GetKeyDown(KeyCode.Escape) && canvasOn == true)
            {
               canvas.gameObject.SetActive(false); 
               canvasOn = false;
            } else{
              return;
            }
        
    }

    public void Quit()
        {
          SceneManager.LoadScene("Menu");
        }

    public void Restart()
      {
        cameraMain.GetComponent<AudioListener>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }

    public void ExitGame()
      {
        Application.Quit();
      }
}
