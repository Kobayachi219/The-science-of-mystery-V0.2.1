using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Under_Sader : MonoBehaviour
{
    public GameObject Sader;
    public GameObject SaderPrefab;
    public float distance = 10;
    public float y = -8;
    public float x = 111;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
