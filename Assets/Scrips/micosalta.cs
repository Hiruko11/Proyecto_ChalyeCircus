using UnityEngine;

public class micosalta : MonoBehaviour
{
    public float speed = 2f;               
    public float jumpForce = 6f;           
    public float detectRadius = 3f;        
    public LayerMask playerLayer;          

    public float jumpCooldown = 0.5f;      


    public Transform groundCheck;          
    public float groundCheckRadius = 0.12f;
    public LayerMask groundLayer;         

    Rigidbody2D rb;
    float lastJumpTime = -999f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>(); 
            rb.gravityScale = 3f;
        }

        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(-Mathf.Abs(speed), rb.linearVelocity.y);

       
        Collider2D player = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

        
        if (player != null && IsGrounded() && Time.time - lastJumpTime >= jumpCooldown)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            lastJumpTime = Time.time;
        }
    }

    bool IsGrounded()
    {
        Vector2 checkPos;
        if (groundCheck != null)
            checkPos = groundCheck.position;
        else
            checkPos = (Vector2)transform.position + Vector2.down * 0.5f;

        Collider2D c = Physics2D.OverlapCircle(checkPos, groundCheckRadius, groundLayer);
        return c != null;
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);

        
        Gizmos.color = Color.yellow;
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        else
            Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.down * 0.5f, groundCheckRadius);
    }
}
