using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IDamageable
{

    [SerializeField]
    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        HealthPoints = TotalHealthPoints;
    }

    void Update()
    {   
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * speed;
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

        TakeHit();
    }

    public void TakeHit()
    {
        HealthPoints--;
        if(HealthPoints <= 0){
            animator.SetLayerWeight(1, 0);
            animator.SetBool("Death", true);
            speed = 0;
            //gameObject.SetActive(false);
        }
    }

}
