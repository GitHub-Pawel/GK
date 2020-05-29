﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -30f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public bool shouldIMove = true;
    public bool isPlayerMoving = false;

    public Transform playerBody;
    Vector3 velocity;
    bool isGrounded;

    [SerializeField] public AudioClip playerMovementSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!shouldIMove)
            return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(playerMovementSound);
            }
        } else
        {
            audioSource.Stop();
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //if (Input.GetButtonDown("Jump") && isGrounded)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        playerBody.position = new Vector3(transform.position.x, playerBody.position.y, transform.position.z);
    }
}
