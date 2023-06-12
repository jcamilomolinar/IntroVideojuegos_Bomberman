using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
        } 
        else if (moveX < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        else if (moveY > 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
        }
        else if (moveY < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
        }
    }

}
