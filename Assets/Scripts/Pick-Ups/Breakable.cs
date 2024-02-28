using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float health = 50;

    // Notice how we assign public to the TakeDmg function
    // This is only used when we want to call this function
    // In another script
    // In this case, this function will be called from the Bullet script
    public void TakeDmg(float dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
