using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    public float DisappearDelay;
    private Animator animator;
    private Vector2 previousPosition;

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        HealthPoints = TotalHealthPoints;
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 difference = currentPosition - previousPosition;

        if (difference.magnitude > 0.01f)
        {
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
            {
                if (difference.x > 0)
                {
                    animator.SetBool("Right", true);
                    animator.SetBool("Left", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                }
                else
                {
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                }
            }
            else
            {
                if (difference.y > 0)
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
        }

        previousPosition = currentPosition;
    }

    public void TakeHit()
    {
        HealthPoints--;
        if(HealthPoints <= 0){
            animator.SetBool("Death", true);
            StartCoroutine(DisappearAfterDelay(DisappearDelay));
        }

    }

    IEnumerator DisappearAfterDelay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Explosion"))
        {
            TakeHit();
        }
    }
}
