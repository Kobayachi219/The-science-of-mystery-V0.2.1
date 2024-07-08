using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPass : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    private void Awake()
    {
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger(name:"Open");
    }
}
