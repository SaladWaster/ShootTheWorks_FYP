using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float eBulletSpeed;

    public float eBulletDamage = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        // This creates a direction directly towards the player
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * eBulletSpeed;

        // Destroy the bullet after it is instantiated, with a lifespan of 1 second
        Destroy(gameObject, 3);
    

        // float bulletRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, 0, bulletRotation);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats playerChar = hitInfo.GetComponent<PlayerStats>();

        if(playerChar != null)
        {
            playerChar.TakeDmg(eBulletDamage);
        }
        
        
        // ONLY ADD THIS LATER, IT'S JUST A HIT EFFECT
        // Instantiate(impactEffect, transform.position, transform.rotation);
        
        //Debug.Log(hitInfo.name);
        Debug.Log($"Enemy Projectile colided with: {hitInfo.name}");
        Destroy(gameObject);
    }
}
