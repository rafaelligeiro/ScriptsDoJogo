using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    
    public GameObject Text;


    void Start()
    {
        Text.gameObject.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(TextAppear());
    }


    IEnumerator TextAppear()
        {
            yield return new WaitForSeconds(2f);

            Text.gameObject.SetActive(true);
        }


    public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
