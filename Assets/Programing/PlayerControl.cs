using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveInput;
    [SerializeField] private float walkspeed = 5;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private itemcollectible playercolor;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * walkspeed, rb.velocity.y);
    }
    
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Collectible collectible))
        {
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
            Destroy(collectible.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
