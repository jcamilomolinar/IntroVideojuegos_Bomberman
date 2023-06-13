using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    public float velocidad;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * velocidad;
        rb.velocity = movement;

        if (moveX > 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetLayerWeight(1, 1);
        } 
        else if (moveX < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetLayerWeight(1, 1);
        }
        else if (moveY > 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetLayerWeight(1, 1);
        }
        else if (moveY < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetLayerWeight(1, 1);
        }
        else if (moveY == 0 && moveX == 0)
        {
            animator.SetLayerWeight(1, 0);
        }
    }

}

