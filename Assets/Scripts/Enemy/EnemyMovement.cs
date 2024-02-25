using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // public EnemyScriptableObject enemyData;

    // EnemyStats enemy;

    // public EnemyMelee enemyMelee;


    [SerializeField] float speed;
    Transform player;

    SpriteRenderer enemySR;

    private Vector2 target;

    Animator animatorE;

    public bool atkPlayer = false;

    public float atkRange;


    /// <summary>
    /// POTENTIAL IMPROVEMENTS
    /// 
    /// circle check/circlecast for player detection
    /// 
    /// </summary>

    

    // Start is called before the first frame update
    void Start()
    {
        // enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerController>().transform;

        enemySR = GetComponent<SpriteRenderer>();

        animatorE = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        target = player.transform.position;

        var x0 = transform.position.x;
        var x1 = player.transform.position.x;
        //enemySR.flipX = x0 > x1;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        
        if(x0 > x1)
        {
            // if the variable isn't empty (ref to our SpriteRenderer)
            if(enemySR != null)
            {
                 // flip the sprite
                 //mySpriteRenderer.flipX = true;

                 // Not only do we flip the sprite, we flip the char AND their colliders + any children entirely
                 transform.eulerAngles = new Vector3(0, 180, 0);
            }

        }
        else if(x0 < x1)
        {
            // if the variable isn't empty (ref to our SpriteRenderer)
            if(enemySR != null)
            {
                 // flip the sprite
                 //mySpriteRenderer.flipX = true;

                 // Not only do we flip the sprite, we flip the char AND their colliders + any children entirely
                 transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }


        
        // Mathf.Abs(x0 - x1) <= 0.5f
        if(distance <= atkRange)
        {
            // Don't move, similar to metal slug soldiers
            Debug.Log("Enemy should attack here~!");

            animatorE.SetBool("IsMoving", false);

            // Call the Attack here

            atkPlayer = true;
        }
        else if(distance >= 2.0f )
        {
            // Don't move, similar to metal slug soldiers
            Debug.Log("Enemy stop here!");

            animatorE.SetBool("IsMoving", false);

        }
        else
        {
            atkPlayer = false;
           
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            animatorE.SetBool("IsMoving", true);
        }

        // transform.position = Vector2.MoveTowards(transform.position, target, step);

        // animatorE.SetBool("IsMoving", true);
        
        // transform.position = Vector2.MoveTowards(transform.position, target, step);

    }
}
