using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{

  public GameObject block;

  void Start()
    {
      block.gameObject.SetActive(true);  
    }

    void Update()
        {
            if(this == null)
                {
                    Destroy(block);
                }
        }
}
