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

    // Attack button
    private bool attackPressed;
 
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

    [Header("Oneway platform mechanics")]
    private bool isOnOnewayPlatform = false;
    [SerializeField]
    private Collider2D playerCollider;

    [Header("Battle")]
    private PlayerEntity playerEntity;
    private bool readyToClear = true;
    private EnemyEntity enemyEntity;
    private Box box;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerEntity = GetComponent<PlayerEntity>();
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
        attackPressed = input.attackPressed;

        if(horizontal != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
        if(isOnOnewayPlatform && vertical < 0 && playerCollider.IsTouchingLayers(groundLayer))
        {
            // diasble the player collider
            playerCollider.isTrigger = true;
        }
        if(attackPressed && readyToClear)
        {
            try
            {
                enemyEntity?.TakeDamage(playerEntity.Damage);
                box?.TakeDamage(playerEntity.Damage);
                readyToClear = false;
                StartCoroutine(Cooldown());
            }
            catch (System.Exception)
            {
                Debug.Log("No enemy to attack");
            }
        }
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


    //Check if is ion oneway platform
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            playerCollider.isTrigger = false;
            isOnOnewayPlatform = false;
            UIManager.Instance.DownButton.SetActive(false);
        }

        if(col.gameObject.CompareTag("Enemy"))
        {
            enemyEntity = col.gameObject.GetComponent<EnemyEntity>();
        }

        if(col.gameObject.CompareTag("Destructible"))
        {
            box = col.gameObject.GetComponent<Box>();
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("OnewayPlatform"))
        {
            isOnOnewayPlatform = true;
            UIManager.Instance.DownButton.SetActive(true);
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        readyToClear = true;
    }
}
