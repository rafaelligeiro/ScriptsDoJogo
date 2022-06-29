using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject Canvas;

    public void LoadGame1()
        {
         Canvas.gameObject.SetActive(true);
         Destroy(gameObject);
        }
}
