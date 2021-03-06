using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (PlayerInput))]
[RequireComponent(typeof (PlayerEntity))]
[RequireComponent(typeof (AnimationPlayer))]
[RequireComponent(typeof (Rigidbody2D))]
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
    private Transform playerOriginPoint;

    [SerializeField]
    private float groundCheckRadius = 0.07f;

    [SerializeField]
    private LayerMask jumpLayer;

    [Header("Oneway platform mechanics")]
    private bool isOnOnewayPlatform = false;

    [SerializeField]
    private Collider2D playerCollider;

    [Header("Battle")]
    private PlayerEntity playerEntity;

    // private bool readyToClear = true;
    // [SerializeField]
    // private Transform attackPoint;
    // [SerializeField]
    // private LayerMask damageableLayer;
    // [SerializeField]
    // private float attackRange = 0.5f;

#region Animator

    [Header("Animation")]
    const string IDLE = "Idle";

    const string WALK = "Walk";

    const string JUMP = "Jump";

    const string HIT = "Hit";

    const string DIE = "Die";

    const string ATTACK = "Attack";

    private AnimationPlayer animationPlayer;

    private Animator animator;

    bool isDead;
#endregion


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerEntity = GetComponent<PlayerEntity>();
        animator = GetComponent<Animator>();
        animationPlayer = GetComponent<AnimationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        GetDownFromOnewayPlatform();

        // Attack();
        Animation();
    }

    void FixedUpdate()
    {
        CheckIfGrounded();
        WalkAndFlip();
        Jump();
    }

    //Check if is ion oneway platform
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            playerCollider.isTrigger = false;
            isOnOnewayPlatform = false;
            UIManager.Instance.DownButton.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("OnewayPlatform"))
        {
            isOnOnewayPlatform = true;
            UIManager.Instance.DownButton.SetActive(true);
        }

        if (col.gameObject.CompareTag("Ground"))
        {
            isOnOnewayPlatform = false;
            UIManager.Instance.DownButton.SetActive(false);
        }
    }

    void GetInput()
    {
        horizontal = input.horizontal;
        vertical = input.vertical;
        horizontalRaw = input.horizontalRaw;
        verticalRaw = input.verticalRaw;
        jumpPressed = input.jumpPressed;
        // grabPressed = input.grabPressed;
        // grabHeld = input.grabHeld;
        // grabReleased = input.grabReleased;
        // attackPressed = input.attackPressed;
    }

    // void Attack()
    // {
    //     return; // Attacking is overrated
    //     if (attackPressed && readyToClear)
    //     {
    //         try
    //         {
    //             Collider2D[] enemies =
    //                 Physics2D
    //                     .OverlapCircleAll(attackPoint.position,
    //                     attackRange,
    //                     damageableLayer);
    //             foreach (Collider2D enemy in enemies)
    //             {
    //                 enemy
    //                     .GetComponent<Entity>()
    //                     .TakeDamage(playerEntity.Damage);
    //             }
    //             animationPlayer.ChangeAnimationState (animator, ATTACK);
    //             readyToClear = false;
    //             StartCoroutine(Cooldown());
    //         }
    //         catch (System.Exception)
    //         {
    //             Debug.Log("No enemy to attack");
    //         }
    //     }
    // }
    void Animation()
    {
        //idle animation
        if (horizontal == 0 && isGrounded && !isDead)
        {
            animationPlayer.ChangeAnimationState (animator, IDLE);
        }
    }

    void WalkAndFlip()
    {
        if (isDead) return;
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (horizontal != 0 && isGrounded)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);

            // play the run/ealk animation
            animationPlayer.ChangeAnimationState (animator, WALK);
        }
    }

    void Jump()
    {
        // jump
        if (jumpPressed && isGrounded && !isDead)
        {
            animationPlayer.ChangeAnimationState (animator, JUMP);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void GetDownFromOnewayPlatform()
    {
        if (isOnOnewayPlatform && vertical < 0)
        {
            // diasble the player collider
            // playerCollider.isTrigger = true;
        }
    }

    void CheckIfGrounded()
    {
        //check if grounded
        isGrounded =
            Physics2D.OverlapCircle(groundCheck.position, 0.2f, jumpLayer);
    }

    public void TookDamage()
    {
        animationPlayer.ChangeAnimationState (animator, HIT);
    }

    public void Died()
    {
        animationPlayer.ChangeAnimationState (animator, DIE);
        isDead = true;
    }

    public void InputHandling(bool enabled)
    {
        if (!enabled)
            input.controls.Player.Disable();
        else
        {
            input.controls.Player.Enable();
            isDead = false;
        }
    }

    // IEnumerator Cooldown()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     readyToClear = true;
    // }
    void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.blue;
        // Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
