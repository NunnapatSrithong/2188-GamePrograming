using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveInput;
    [SerializeField] private float walkspeed = 5;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private itemcollectible playercolor;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] Transform player;

    
    public void SetAnimetorParameter(Vector2 playervelocity, bool groundState)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(playervelocity.x));
        animator.SetBool("isGrounded", groundState);
    }

    private void SetAnimatorParameters()
    {
        SetAnimetorParameter(rb.velocity, CheckGrounded());
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * walkspeed, rb.velocity.y);
        
        if (CheckGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;

        }
        SetAnimatorParameters();
    }
    
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        FlipPlayer();
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed && coyoteTimeCounter > 0 )
        {
            rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
            coyoteTimeCounter = 0;
        }
    }

    private void FlipPlayer()
    {
        if (moveInput < 0)
        {
            player.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput > 0)
        {
            player.localScale = Vector3.one;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Collectible collectible))
        {
            Debug.Log("Colletible is touhed");
            itemcollectible playerColor = collectible.color;

            switch (playerColor)
            {
                case itemcollectible.Yellow:
                    spriteRenderer.color = Color.yellow;
                    break;
                case itemcollectible.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case itemcollectible.Red:
                    spriteRenderer.color = Color.red;
                    break;
            }

           
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.LoadNextLevel();
        }
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        GameManager.instance.ProcessPlayerDeath();
    }

    private bool CheckGrounded()
    {
        float extendedHeight = 0.05f;
        Bounds boxColliderBar = boxCollider2D.bounds;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxColliderBar.center, boxColliderBar.size,
             0f, Vector2.down, extendedHeight, groundLayer);

        return raycastHit2D.collider != null;
    }
    void Start()



    {
        
    }
    void Update()
    {
        
    }
}
