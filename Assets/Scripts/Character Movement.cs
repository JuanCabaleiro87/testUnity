using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public float rotationSpeed = 500.0f;
    public float jumpforce = 10.0f;
    public float dashForce = 10.0f;

    float initalSpeed = 0.0f;
   
    private Rigidbody Physics;
    
        
    // Start is called before the first frame update
    void Start()
    {
        //bloquear y ocultar cursor
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        //fisicas
        Physics = GetComponent<Rigidbody>();
        initalSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {   
        //Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);
        //Camara
        float rotationY = Input.GetAxis("Mouse X");
        
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0));

        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);

        }
        //correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }        

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initalSpeed;
        }        
        //dash
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Physics.AddForce(new Vector3(horizontal * dashForce, 0 , vertical * dashForce), ForceMode.Impulse);
        }       
        //ataque
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("ataque debil");
        } 

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("ataque fuerte");
        } 
    }
}
