using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible: MonoBehaviour
{
    public SpeedPower speedPower;
    public ExtraBombPower extraBombPower;
    public BlastRadiusPower blastRadiusPower;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
            Vector2 position = transform.position;

            if (Random.value < 1)
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
}
