using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour
{
    //referencia al CharacterController
    public CharacterController controller;
    
    //velocidad de movimiento
    public float speed = 5;

    //suavidad de rotacion
    public float turnSmoothTime = 0.1f;

    //velocidad de rotacion
    float turnSmoothVelocity;

    //referencia a la camara
    public Transform cam;

    //fuerza de gravedad
    public float gravity = -9.8f;

    //altura de salto
    public float jumpHeight = 3;

    //referencia al ground check
    public Transform groundCheck;
    public float groundDistance = 0.3f;

    //referencia al layermask (mascara del suelo)
    public LayerMask groundmask;

    //velocidad durante el salto?
    Vector3 jumpVelocity;

    //comprobar si esta en el suelo
    bool isGrounded;

    //referencia al animator
    public Animator animator;


    void Update()
    {
        //comprobar si esta en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        //aplica velocidad hacia abajo mientras esta en el suelo
        if (isGrounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
        }


        //Leer direccion
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

        //asignar direcciones al animador
        animator.SetFloat("Velx", horizontal);
        animator.SetFloat("Vely", vertical);

        //animacion de guardia
        if (Input.GetKey("f"))
        {
            animator.SetBool("Other", false);
            animator.Play("Guard");
        }

        //animacion de golpe de puño
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Other", false);
            animator.Play("Punch");
        }

        //salir de guardia
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Other", true);
        }


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        //mover
        if (direction.magnitude >= 0.1f)
        {
            //leer angulo de rotacion
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //suavidad de rotacion
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0)* Vector3.forward;

            //rotacion
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //traslacion del modelo
            controller.Move(moveDir.normalized * speed*Time.deltaTime);
        }

        //saltar
        if(Input.GetKeyDown("space") && isGrounded)
        {
            animator.Play("Jump");
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

        jumpVelocity.y += gravity * Time.deltaTime;

        controller.Move(jumpVelocity * Time.deltaTime);

    }
}
