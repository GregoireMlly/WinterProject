using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private float mouseSensitivityX = 3f;
    
    [SerializeField]
    private float mouseSensitivityY = 3f;

    private PlayerMotor motor;
    public Animator animator;
    public Animator anim;

    private bool LancerBoule;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Calculer la vélocité (vitesse) du mouvement de notre joueur
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
        
        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;
        
        //Jouer animation perso du Lancer de boule
        animator.SetFloat("Horizontal", xMov);
        animator.SetFloat("Vertical", zMov); 
        
        /*
        
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Lancer", true);
        }

        if (!(Input.GetButtonDown("Fire1")))
        {
            animator.SetBool("Lancer", false);
        }
        */
        motor.Move(velocity);
        
        // On calcule la rotation du joueur en un Vector3
        float yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);
        
        // On calcule la rotation de la caméra en un Vector3
        float xRot = Input.GetAxisRaw("Mouse Y");
        
        float cameraRotationX = xRot * mouseSensitivityY;

        motor.RotateCamera(cameraRotationX);
    }
}
