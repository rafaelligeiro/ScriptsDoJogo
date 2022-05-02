using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChange : MonoBehaviour
{
    [SerializeField] private Dialog_Effect Efeito;

    public Text Text1, Text2, Text3, Text4, Text5, Text6, Text7;
    public GameObject Line1, Line2, Line3, Line4, Line5, Line6, Line7, dialogueBox, player;

    // Start is called before the first frame update
    void Start()
    {
        Line1.gameObject.SetActive(true);
        Line2.gameObject.SetActive(false);
        Line3.gameObject.SetActive(false);
        Line4.gameObject.SetActive(false);
        Line5.gameObject.SetActive(false);
        Line6.gameObject.SetActive(false);
        Line7.gameObject.SetActive(false);
        Efeito.AddWriter(Text1, "She was a lovely woman..", .05f);
    }

    void Update()
        {
          if(Input.GetMouseButtonDown(0))
            {
                if(Line1.activeSelf)
                    {
                     Line1.gameObject.SetActive(false);
                     Line2.gameObject.SetActive(true);
                     Efeito.AddWriter(Text2, "Are you Steve?", .05f);   
                    }
                    else if(Line2.activeSelf)
                    {
                     Line2.gameObject.SetActive(false);
                     Line3.gameObject.SetActive(true);
                     Efeito.AddWriter(Text3, "Who's Steve?", .05f);   
                    }
                   else if(Line3.activeSelf)
                    {
                     Line3.gameObject.SetActive(false);
                     Line4.gameObject.SetActive(true);
                     Efeito.AddWriter(Text4, "Don't you remember your bestfriend Steve?", .05f);
                    }
                    else if(Line4.activeSelf)
                    {
                     Line4.gameObject.SetActive(false);
                     Line5.gameObject.SetActive(true);
                     Efeito.AddWriter(Text5, "Listen old man, I just want to get out of here.", .05f); 
                    } 
                    else if(Line5.activeSelf)
                    {
                     Line5.gameObject.SetActive(false);
                     Line6.gameObject.SetActive(true);
                     Efeito.AddWriter(Text6, "Oh.. They must be Steve guardians then..", .05f);  
                    }
                    else if(Line6.activeSelf)
                    {
                     Line6.gameObject.SetActive(false);
                     Line7.gameObject.SetActive(true);
                     Efeito.AddWriter(Text7, "You should take this, I don't need it.", .05f);   
                    }
                    else if(Line7.activeSelf)
                    {
                     Line7.gameObject.SetActive(false);
                     dialogueBox.gameObject.SetActive(true);
                     player.gameObject.SetActive(true);
                     Destroy(gameObject);
                    }  
            }

        }
        
}
