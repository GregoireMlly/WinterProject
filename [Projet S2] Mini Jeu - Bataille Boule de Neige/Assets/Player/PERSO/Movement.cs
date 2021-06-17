using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    public int jump = 5;
    public int gravity = 20;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController Cc;
    private Animator anim;
    //DirectionDeplacement = Vector3.zero;
    //private CharacterController Player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //déplacement
        if (Cc.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed*29); // a voir pour changer la vitesse de rotation
        Cc.Move(moveDirection * Time.deltaTime);
        //Gravité
        moveDirection.y -= gravity * Time.deltaTime;
        
        //Saut
        if(Input.GetKey(KeyCode.Space) && Cc.isGrounded)
        {
            moveDirection.y = jump*10;
        }
        //Animation
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("walk", true);

        }
        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("walk", false);

        }

        /*DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        Player.Move(DirectionDeplacement * Time.deltaTime * speed);*/
        //transform.Rotate(0,Input.getAxisRaw("Left"))
    }
}
