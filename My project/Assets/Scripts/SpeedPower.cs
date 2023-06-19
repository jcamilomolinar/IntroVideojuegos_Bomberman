using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPower : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            if (player != null)
            {
                player.speed += (float)0.5;
            }
            Destroy(gameObject);
        }
    }
}
