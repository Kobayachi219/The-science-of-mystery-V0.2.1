using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Respawn : MonoBehaviour
{
    Vector2 CheckpointPos;
    Rigidbody2D rb;
    [SerializeField] private Light Light;
    [SerializeField] private BoxCollider2D BoxCollider2D;
    CameraMovement cameraController;
    // Start is called before the first frame update
    public Animation Animation;
    private PlayerMovement PlayerMovement;
    public ParticleSystem ParticleSystem;

    
    

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        rb = GetComponent<Rigidbody2D>();
        ParticleSystem = GetComponent<ParticleSystem>();
        Animation = GetComponent<Animation>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        
    }
   /* IEnumerator CheckScaleWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if (rb.transform.localScale == new Vector3((float)-0.4751819, (float)0.4751819, (float)0.158394))
        {
            Debug.Log("Hello");
        }
    }*/
    void Start()
    {
        CheckpointPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Die();
            GameObject[] trapCheckObjects = GameObject.FindGameObjectsWithTag("TrapCheck");


            foreach (GameObject obj in trapCheckObjects)
            {
                BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.enabled = true;
                }
            }
        

    }
        if (collision.CompareTag("TrapCheck"))
        {
            if (rb.transform.localScale == new Vector3((float)-0.6030463, (float)0.6030463, (float)0.2010154))
            {
                transform.localScale = new Vector3((float)0.6030463, (float)0.6030463, (float)0.2010154);
                //  transform.position = startpos;
                Debug.Log("debug TrapCheck");

                GameObject[] trapCheckObjects = GameObject.FindGameObjectsWithTag("TrapCheck");

                
                foreach (GameObject obj in trapCheckObjects)
                {
                    BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
                    if (collider != null)
                    {
                        collider.enabled = false; 
                    }
                }
            }

            Debug.Log("debug 1");
        }


    }
    void Reverpls()
    {
        transform.position = CheckpointPos;
        transform.localScale = new Vector3((float)0.6030463, (float)0.6030463, (float)0.2010154);

    }
    public void UpdateCheckPoint(Vector2 Pos)
    {
        CheckpointPos = Pos;
    }
    void Die()
    {
        
        //cameraController.Animation.Play("WhiteScreen");


        StartCoroutine(Respaw(0.5f));

        

        //StartCoroutine(CheckScaleWithDelay(2.0f));
        // ParticleSystem.Play();

    }

    IEnumerator Respaw(float duration)
    {
        
        BoxCollider2D.enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        PlayerMovement.enabled = false;
        transform.localScale = new Vector3(0, 0, 0);
        rb.simulated = false;
        Light.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = CheckpointPos;  
        transform.localScale = new Vector3((float)0.6030463, (float)0.6030463, (float)0.2010154);
        rb.simulated = true;
        Light.enabled = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerMovement.enabled = true;

        



    }
   /* private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            //animator.SetBool("isDash", false);
        }
    }*/
}
