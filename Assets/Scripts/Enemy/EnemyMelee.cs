using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask playerLayers;

    public float meleeDamage = 50;

    // No. of times player can attack (per second)
    //public float attackRate = 1f;
    //float nextAttackTime = 0f;

    private float timer;
    public float meleeCD;

    public EnemyMovement eMove;


    /// THE ENEMY IS NOT FLIPPING THE ATK POS ATM

    /// <summary>
    /// POTENTIAL IMPROVEMENTS
    /// 
    /// 
    /// KEY: CAN REUSE THIS ATTACK RATE FOR PROJECTILE ATTACKS
    /// 
    /// MAYBE CHANGE SHAPE TO BOX COLLIDERS LIKE OTHER PROJECTILE ATTACKS?
    /// 
    /// </summary>
  


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(eMove.atkPlayer)
        {
            // // Time.time keeps track of our current time
            // if(Time.time >= nextAttackTime)
            // {
            //         Attack();

            //         // Modify attackRate in inspector to decide how many times player can attack per second
            //         nextAttackTime = Time.time + 1f / attackRate;
        
            // }

            timer += Time.deltaTime;

            if(timer > meleeCD)
            {
                timer = 0;
                Attack();
            }
        }

        
        
    }

    void Attack()
    {
        animator.SetTrigger("EnemyMelee");

        print("Enemy Attack Check!");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
    

        foreach(Collider2D player in hitPlayer)
        {
            Debug.Log("We hit" + player.name);

            player.GetComponent<PlayerStats>().TakeDmg(meleeDamage);
        }
    }


    // Draw the shape whenever an object is selected
    void OnDrawGizmosSelected() 
    {

        if (attackPoint == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        
    }
}
