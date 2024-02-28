using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health = 100;

    // DMG Flash
    [SerializeField] private DamageFlash flashEffect;

    // public GameObject deathEffect;


    void FixedUpdate()
    {
        // Checks if Enemy has fallen off the map
        // We destroy immediately, do not give points to player
        if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }


    // Notice how we assign public to the TakeDmg function
    // This is only used when we want to call this function
    // In another script
    // In this case, this function will be called from the Bullet script
    public void TakeDmg(float dmg)
    {
        health -= dmg;

        flashEffect.Flash();

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        // ... The below code disables components so enemy cant continue behaviour on death...
        // ... This can help with letting animations playout, based on MELEE COMBAT in Unity
        // ... Do more research and return to this after, on how to let death animations play before despawn...

        //this.enabled = false;
        // GetComponent<Collider2D>().enabled = false;
        //GetComponent<EnemyMovement>().enabled = false;
        PointCounter.instance.IncreasePoints(1);

        // Destroy on death
        Destroy(gameObject);
    }
}
