using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_assistant : MonoBehaviour
{


    [SerializeField] private Dialog_Effect Efeito;

    private Text messageText;



    private void Awake() 
    {
        messageText = transform.Find("messageText").GetComponent<Text>();
    }

    private void Start()
    {



        Efeito.AddWriter(messageText, "Where am I?", .1f);
    }
}
