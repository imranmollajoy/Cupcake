using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("Input")]
    [SerializeField]
    PlayerInput input;
    // Horizontal and vertical axis input
    private float horizontal;
    private float vertical;
    private float horizontalRaw;
    private float verticalRaw;
 
    // Jump button
    private bool jumpPressed;
 
    // Grab button
    private bool grabPressed;
    private bool grabHeld;
    private bool grabReleased;
 

    [Header("Movement")]
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpForce = 5f;
    private Vector3 velocity;

    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = input.horizontal;
        vertical = input.vertical;
        horizontalRaw = input.horizontalRaw;
        verticalRaw = input.verticalRaw;
        jumpPressed = input.jumpPressed;
        grabPressed = input.grabPressed;
        grabHeld = input.grabHeld;
        grabReleased = input.grabReleased;

    }

    void FixedUpdate()
    {
        //check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // jump
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
