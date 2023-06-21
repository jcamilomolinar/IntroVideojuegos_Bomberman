using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible: MonoBehaviour
{
    [SerializeField]
    public SpeedPower speedPower;
    public ExtraBombPower extraBombPower;
    public BlastRadiusPower blastRadiusPower;
    private Animator animator;
    public float DisappearDelay;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Explosion"))
        {
            animator.SetBool("ExplosionTouch", true);
            StartCoroutine(DisappearAfterDelay(DisappearDelay));
            Vector2 position = transform.position;

            if (Random.value < 0.3)
            {
                float randomValue = Random.value;
                if (randomValue < 0.33)
                {
                    SpeedPower powerUp = Instantiate(speedPower);
                    powerUp.transform.position = transform.position;
                } 
                else if (randomValue < 0.66) 
                {
                    ExtraBombPower powerUp = Instantiate(extraBombPower);
                    powerUp.transform.position = transform.position;
                } 
                else 
                {
                    BlastRadiusPower powerUp = Instantiate(blastRadiusPower);
                    powerUp.transform.position = transform.position;
                }
            }
        }
    }

    IEnumerator DisappearAfterDelay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        gameObject.SetActive(false);
    }
}
