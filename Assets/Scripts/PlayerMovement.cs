using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private bool Grounded;
    public Rigidbody2D Rigidbody2D;

    public float moveSpeed = 5f;  // Adjustable movement speed
    private float Horizontal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (left and right movement)
        Horizontal = Input.GetAxisRaw("Horizontal");
        
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f))
        {
            Debug.Log("Touch");
            Grounded = true;
        }
        else Grounded = false;

        

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }
    }

private void Jump()

    {
        
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        // Update the Rigidbody2D's velocity with horizontal movement and current Y velocity
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * moveSpeed, Rigidbody2D.linearVelocity.y);
    }
}