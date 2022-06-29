using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

  public void LoadCutscene()
    {
       Application.LoadLevel("Game_Opening"); 
    }

  public void LoadTutorial()
    {
        Application.LoadLevel("PAP backup");
    }

   public void LoadScene1()
    {
       Application.LoadLevel("PAP backupTest"); 
    }

    public void LoadScene2()
    {
       Application.LoadLevel("NewScenario"); 
    }
}
