using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    [SerializeField]
    float jumpHeight;


    Rigidbody2D rb;

    SpriteRenderer enemySR;

    bool grounded;

    void Awake()
    {
        // Check the player object for a component of type Rigidbody2D
        // This script takes the Rigidbody2D found and stores it inside the body vairable
        // One of most widely used methods to make references, works with colliders and more
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {        
        enemySR = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(grounded)
        {
            Jumper();
        }

    }


    void Jumper()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        grounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if object collided with is the ground
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
