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
    private Vector2 previousPosition;

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
        Vector2 currentPosition = transform.position;
        Vector2 difference = currentPosition - previousPosition;

        if (difference.magnitude > 0.01f)
        {
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
            {
                // El objeto se está moviendo principalmente en el eje horizontal (izquierda o derecha)
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
                // El objeto se está moviendo principalmente en el eje vertical (arriba o abajo)
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
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }

        previousPosition = currentPosition;
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
