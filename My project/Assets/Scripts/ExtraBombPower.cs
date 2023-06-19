using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBombPower : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            BombDefault bomb = collision.gameObject.GetComponent<BombDefault>();
            if (bomb != null)
            {
                bomb.bombStarterAmount += 1;
            }
            Destroy(gameObject);
        }
    }
}
