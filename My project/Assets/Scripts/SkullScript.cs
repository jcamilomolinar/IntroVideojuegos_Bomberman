using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    public float speed = 1;
    public float DisappearDelay;
    private Rigidbody2D rb;
    private Animator animator;
    public float counter;

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        HealthPoints = TotalHealthPoints;
    }

    void Update()
    {   
        float randomValue = Random.value;
        if (randomValue < 0.25)
            {
                animator.SetBool("Right", true);
                animator.SetBool("Left", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
            }
            else if (randomValue < 0.5)
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", true);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
            }
            else if (randomValue < 0.75)
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
            }
            else
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);
            }
    }

    public void TakeHit()
    {
        HealthPoints--;
        if(HealthPoints <= 0){
            animator.SetBool("Death", true);
            speed = 0;
            StartCoroutine(DisappearAfterDelay(DisappearDelay));
        }
    }

    IEnumerator DisappearAfterDelay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Explosion"))
        {
            TakeHit();
        }
    }
}
