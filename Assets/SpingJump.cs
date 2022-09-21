using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpingJump : MonoBehaviour
{
    [SerializeField] private BoxCollider2D jumpingPadCollider;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerControl player))
        {
            player.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            animator.SetTrigger("jump");
        }
    }

}
