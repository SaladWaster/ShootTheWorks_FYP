using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20f;
    public float bulletDamage = 40;
    public Rigidbody2D rb;

    // public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;

        // Destroy the bullet after it is instantiated, with a lifespan of 1 second
        Destroy(gameObject, 1);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyStats badGuy = hitInfo.GetComponent<EnemyStats>();
        Breakable breakObject = hitInfo.GetComponent<Breakable>();

        if(badGuy != null)
        {
            badGuy.TakeDmg(bulletDamage);
        }
        else if(breakObject != null)
        {
            breakObject.TakeDmg(bulletDamage);
        }
        
        
        // ONLY ADD THIS LATER, IT'S JUST A HIT EFFECT
        // Instantiate(impactEffect, transform.position, transform.rotation);
        
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    
}
