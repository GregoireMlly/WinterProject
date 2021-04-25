using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCerf : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("walk", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("walk back", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("walk back", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("lancerBoule");
        }
    }
}
