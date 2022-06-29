using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutsceneHandle : MonoBehaviour
{

    private Animator anim;
    public GameObject otherPartAnim;
    public GameObject tree;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(goodbye());
    }

    IEnumerator goodbye()
        {
            yield return new WaitForSeconds(0.25f);
            otherPartAnim.gameObject.SetActive(true);
            tree.gameObject.SetActive(false);
            Destroy(gameObject);
        }

}
