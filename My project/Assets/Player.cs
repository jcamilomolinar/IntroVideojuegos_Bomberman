using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX > 0)
        {
            animator.SetTrigger("Right");
        }
        else if (moveX < 0)
        {
            animator.SetTrigger("Left");
        }
        else if (moveY > 0)
        {
            animator.SetTrigger("Up");
        }
        else if (moveY < 0)
        {
            animator.SetTrigger("Down");
        }
    }
}
