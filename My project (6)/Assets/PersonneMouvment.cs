using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonneMouvment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    //velocity
    Vector3 velocity;
    public float gravity = -9.81f;
    //ground check
    public Transform groundcheck;
    //the radius of the sphere tghat well be using to check
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    //to controle what object this sphere should check for
    bool isGrounded;
    void Update()
    {
       
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Vector3 move = new Vector3(x, 0f, z); 
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown("a"))
        {
            Collision.enter = false;
            
        }
        if (Collision.enter == false)
        {
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        
    }
    }
