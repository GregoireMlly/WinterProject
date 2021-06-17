using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            animator.SetBool("isWalking", true);
        }
        
        if (!Input.GetKey("z"))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
