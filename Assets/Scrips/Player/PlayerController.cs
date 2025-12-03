using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Referencia al Rigidbody2D del jugador (componente físico) que controla la velocidad y la física.
    Rigidbody2D playerRb;

    // Referencia al componente PlayerInput (sistema de Input System de Unity) para leer acciones.
    PlayerInput playerInput;

    // Referencia al Animator para controlar las animaciones del personaje
    // (por ejemplo parámetros como "walk", "jump", etc.).
    Animator controlanimator;

     public AudioClip JumpSFX;

    // Permite ajustar la velocidad en el inspector con un rango visual de 0 a 5.
    [Range(0f, 5f)]
    public float Speed; // Velocidad horizontal del jugador.

    [Header("Ground Check")]

    // Indica si el jugador está tocando el suelo. Se actualiza cada frame en Update().
    public bool isGrounded;

    // Radio del círculo usado en el CircleCast para el chequeo de suelo.
    public float radius;

    // Distancia desde la posición del jugador hacia abajo donde se hace el CircleCast.
    public float distance;

    public float jumpForce;


    // Start se llama una vez cuando el objeto se inicializa en la escena.
    void Start()
    {
        // Obtiene y cachea la referencia al Rigidbody2D adjunto al mismo GameObject.
        playerRb = GetComponent<Rigidbody2D>();

        // Obtiene y cachea la referencia al componente PlayerInput para leer entradas.
        playerInput = GetComponent<PlayerInput>();

        controlanimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Comprueba si el jugador está en el suelo.
        // Se usa Physics2D.CircleCast para proyectar un círculo hacia abajo desde la posición
        // del jugador; si colisiona con la capa "Ground" el resultado será true.
        // LayerMask.GetMask("Ground") construye la máscara de capas usada en la comprobación.
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector2.down, distance, LayerMask.GetMask("Ground"));

        if (playerInput.actions["Jump"].WasPressedThisFrame() && isGrounded)
        {
            Jump();
       

        }
             if(playerInput.actions["Pausa"].WasPressedThisFrame())
        {
            GameManager.Instance.PausedGame();
        }
    }

    // FixedUpdate se usa para lógica relacionada con la física y se ejecuta en intervalos fijos.
    void FixedUpdate()
    {
        // Llama al método que procesa el movimiento del jugador.
        PlayerMovement();
    }

    // Maneja la lectura de entrada y aplica la velocidad horizontal al Rigidbody2D.
    void PlayerMovement()
    {
        // Lee el valor de la acción "Move" (un Vector2 normalmente: x = horizontal, y = vertical).
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        // Asigna la velocidad horizontal al rigidbody, manteniendo la velocidad vertical actual.
        // Nota: se usa playerRb.linearVelocity (propiedad de Unity 2023+) en lugar de velocity.
        playerRb.linearVelocity = new Vector2(moveInput.x * Speed, playerRb.linearVelocity.y);

        // Si el jugador se mueve hacia la derecha (x > 0), aseguramos la escala local positiva
        // para que el sprite mire a la derecha.
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Si se mueve hacia la izquierda (x < 0), invertimos la escala en X para voltear el sprite.
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }




        if (moveInput.x != 0 && isGrounded)
        {
            controlanimator.SetBool("walk", true);
        }
        else
        {
            controlanimator.SetBool("walk", false);
        }
        if (!isGrounded)
        {
            controlanimator.SetBool("jump", true);
        }
        else
        {
            controlanimator.SetBool("jump", false);
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        AudioManager.Instance.PlaySFX(JumpSFX);


    }

  
    void OnDrawGizmos()
    {
        // Dibuja en la ventana de escena un gizmo para visualizar el Ground Check.
        // Esto ayuda a ajustar 'radius' y 'distance' durante el desarrollo.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * distance, radius);
    }
   
}
