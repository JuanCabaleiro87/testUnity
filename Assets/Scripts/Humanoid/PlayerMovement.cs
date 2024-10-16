using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 5;
    public float rotationSpeed = 200;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;
    public float jumpHeight = 1;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;
    void Update()
    {
        //caminar
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        animator.SetFloat("Velx", x);
        animator.SetFloat("Vely", y);

        //guardia
        if (Input.GetKey("f"))
        {
            animator.SetBool("Other", false);
            animator.Play("Guard");
        }

        //salir de guardia
        if (x != 0 || y != 0)
        {
            animator.SetBool("Other", true);
        }

        //salto
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKey("space") && isGrounded)
        {
            animator.Play("Jump");
            //Invoke("Jump", 0.5f);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
    public void Jump()
    {
         rb.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
    }
}
