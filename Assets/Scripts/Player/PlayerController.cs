using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //public BasicAttack basicAttack;

    public float cooldownDuration = 0;

    //public bool coolingDown = true;


    Vector2 movement;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpHeight;

    //References the player character Scriptable Object for stats
    Rigidbody2D rb;

    SpriteRenderer mySpriteRenderer;

    bool grounded;


    Animator animatorP;
    

    void Awake()
    {
        // Check the player object for a component of type Rigidbody2D
        // This script takes the Rigidbody2D found and stores it inside the body vairable
        // One of most widely used methods to make references, works with colliders and more
        rb = GetComponent<Rigidbody2D>();

        // Refers to spriterender
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animatorP = GetComponent<Animator>();
    }

    void Update()
    {
        //transform.Translate(movement * Time.deltaTime);

        Run();

        // Only triggers jump if player is considered grounded
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // if(Input.GetKey(KeyCode.I))
        // {
        //     BasicAttack();
        // }

        // if(Input.GetKey(KeyCode.O))
        // {
        //     StopAttack();
        // }

        // if (coolingDown)
        // {
        //     if (cooldownDuration > 0)
        //     {
        //         cooldownDuration -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         StopAttack();                
        //     }
            
        // }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        grounded = false;

        //animatorP.SetTrigger("jump");
    }
    

    void Run()
    {
        float moveLR = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveLR * moveSpeed , rb.velocity.y);

        // transform.Translate(movement * Time.deltaTime * moveSpeed);

        // if moving Left, flip the sprite
        // if no button is pressed, we do not flip. Only flip in opp direciton, so we ignore 0f
        if(moveLR < 0f)
        {
            // if the variable isn't empty (ref to our SpriteRenderer)
            if(mySpriteRenderer != null)
            {
                 // flip the sprite
                 //mySpriteRenderer.flipX = true;

                 // Not only do we flip the sprite, we flip the char AND their colliders + any children entirely
                 transform.eulerAngles = new Vector3(0, 180, 0);
            }

            animatorP.SetBool("isMoving", true);
        }
        else if(moveLR > 0f)
        {
           
            if(mySpriteRenderer != null)
            {
                 // flip the sprite
                 //mySpriteRenderer.flipX = false;

                 // Not only do we flip the sprite, we flip the char AND their colliders + any children entirely
                 transform.eulerAngles = new Vector3(0, 0, 0);
            }

            animatorP.SetBool("isMoving", true);
        }
        else
        {
            animatorP.SetBool("isMoving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if object collided with is the ground
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    

    void OnMove(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
    }

    // public void BasicAttack()
    // {
        

    //     if (mySpriteRenderer.flipX)
    //     {
    //         basicAttack.AttackLeft();
    //     }
    //     else
    //     {
    //         basicAttack.AttackRight();
    //     }

    //     animatorP.SetTrigger("meleeAttack");

    //     coolingDown = true;
    // }

    // public void StopAttack()
    // {
    //     basicAttack.StopAttack();
    //     coolingDown = false;
    //     cooldownDuration = 1;
    // }
}
