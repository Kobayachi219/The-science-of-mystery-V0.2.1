using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class LavaUpper : MonoBehaviour
{
    [SerializeField] public Sprite newSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private SpriteRenderer spritedoor;
    public Behaviour ScriptA;
    public Animator animator;

    public TMP_Text text;
    public TMP_Text text2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            ChangeSprite();
            ChangeDoor();
            text2.text = "Escape the lava";
            text2.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            text.text = "press E !";
            text.enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {



            text.enabled = false;

        }
    }

    void ChangeSprite()
    {

        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
    void ChangeDoor()
    {
        animator.SetTrigger("LavaUpper");
    }

}
