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


    void Update()
    {
        //Leer direccion
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

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
    }
}
