using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPower : MonoBehaviour
{
    [SerializeField]
    public PlayerMove player;

    void increaseSpeed()
    {
        player.speed += 1;
    }
}
