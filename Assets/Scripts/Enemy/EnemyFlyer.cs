using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyer : MonoBehaviour
{
    public float speed;     // Move speed

    // public int startPoint;      // Starting index (pos of platform)
    public Transform[] points;      // Array of transform pts (positions where platform moves)
    
    private int i; // index of the above Array

    public float contactDamage = 1000;

    void Start()
    {
        // Set pos of enemy to that of points using index startPoint
        // transform.position = points[startPoint].position;
        
    }

    // Update is called once per frame
    void Update()
    {

        /* CODE HERE THAT ONLY BEINGS MOVEMENT IF PLAYER IS CLOSE ENOUGH,
        ALSO, THE CHECK DISTANCE MUST BE IGNORED ONCE IT FLIES PAST THE PLAYER, AND DESPAWN THE ENEMY AFTER A SET DISTANCE/TIME, WHERE IT SHOULD BE OFFSCREEN
        */



        // Check distance of enemy and point
        // If the enemy and the current point position is very close enough,
        // Update the point to the next point
        if (Vector2.Distance(transform.position, points[i].position) <0.002f)
        {
            i++;    // increase index

            // Destroy the enemy if it has not yet been defeated by player at end of pathing
            if(i == points.Length)
            {
                i = 0;
                Destroy(gameObject);
            }
        }

        // Move the platform to point position with index "i"

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
        
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerChar = collision.gameObject.GetComponent<PlayerStats>();
            playerChar.TakeDmg(contactDamage); // Use current damage, as we may add damage modifiers later, rather than weapondata.damage
        }

        
    }




}
