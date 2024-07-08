using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vib : MonoBehaviour
{
    public Behaviour ScriptA;
    public TMP_Text text;
    
   /* private Collider2D collider2D;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();    
    }*/
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
            
                Game_Contoller.instance.nextChapter();
           
        }
    }
   
}
