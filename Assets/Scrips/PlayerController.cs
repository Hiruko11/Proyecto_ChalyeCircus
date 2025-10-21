using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    PlayerInput playerInput;

    [Range(0f, 5f)]

    public float Speed;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        PlayerMovement();
    }
    
    void PlayerMovement()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        playerRb.linearVelocity = new Vector2(moveInput.x * Speed, playerRb.linearVelocity.y);

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
