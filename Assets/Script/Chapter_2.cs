
using UnityEngine;

public class Chapter_2 : MonoBehaviour
{
    public Behaviour ScriptA;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
            if (collision.CompareTag("Player")) 
            {
                Game_Contoller.instance.nextChapter();
            }
      
        
    }
}
