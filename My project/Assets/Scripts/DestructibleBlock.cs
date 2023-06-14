using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlock : MonoBehaviour, IDamageable
{

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    
    void Update()
    {
        TakeHit();
        //Here is the logic for the explosions
    }

    public void TakeHit()
    {
        HealthPoints--;
        if(HealthPoints <= 0){
            gameObject.SetActive(false);
        }
    }
}
