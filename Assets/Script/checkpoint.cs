using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class checkpoint : MonoBehaviour
{
    Respawn gamecontoller;
    public Transform respawnpoint;
    public TMP_Text text;
    [SerializeField] private BoxCollider2D BoxCollider2D;
    [SerializeField] private float time;
    private void Awake()
    {
        gamecontoller = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            gamecontoller.UpdateCheckPoint(respawnpoint.position);
            StartCoroutine(Text(time));
            BoxCollider2D.enabled = false;
            
        }
    }

    IEnumerator Text(float duration)
    {
        text.text = "New Checkpoint!";
        text.enabled = true;
        yield return new WaitForSeconds(duration);
        text.enabled = false;
    }
}
