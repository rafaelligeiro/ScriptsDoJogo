using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIalogueEffect2 : MonoBehaviour
{


    [SerializeField] private Dialog_Effect Efeito;

    private Text Text;



    private void Awake() 
    {
        Text = transform.Find("Text").GetComponent<Text>();
    }

    private void Start()
    {

        Efeito.AddWriter(Text, "Where am I?", .1f);
    }
}
