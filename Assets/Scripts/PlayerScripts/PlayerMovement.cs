using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // public float moveSpeed = 3f;
    //
    // public Transform playerCamera;
    // public CharacterController controller;
    // public GameObject walking;
    // public GameObject breathing;
    public CharacterController controller;
    public GameObject walking;
    public float speed = 12f;
    //public float gravity = -9.81f * 2;
    //public float jumpHeight = 3f;
 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
 
    Vector3 velocity;
 
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        walking.SetActive(false);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0 || z != 0)
        {
            walking.SetActive(true);
        }
        else
        {
            walking.SetActive(false);
        }
        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;
        move.y = 0;
        controller.Move(move * speed * Time.deltaTime);
 
        if (!isGrounded)
        {
            controller.Move(Vector3.down * 5f * Time.deltaTime);
        }
        //check if the player is on the ground so he can jump
        
        //controller.Move(velocity * Time.deltaTime);
        
        
        
        
        
        
        // float verticalAxis = Input.GetAxis("Vertical");
        // float horizontalAxis = Input.GetAxis("Horizontal");
        //
        // if (horizontalAxis != 0 || verticalAxis != 0)
        // {
        //     walking.SetActive(true);
        //     Vector3 moveDirection = playerCamera.transform.forward * verticalAxis +
        //                             playerCamera.transform.right * horizontalAxis;
        //     moveDirection.y = 0;
        //     transform.position += moveDirection * moveSpeed * Time.deltaTime;
        //     
        // }
        // else
        // {
        //     
        // walking.SetActive(false);
        // }
        //

    }
    

    void OnCollisionEnter(Collision collision)
    {
    
    }
}
