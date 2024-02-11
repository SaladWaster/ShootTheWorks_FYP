using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public float meleeDamage = 50;

    // No. of times player can attack (per second)
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    /// <summary>
    /// POTENTIAL IMPROVEMENTS
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

        // Time.time keeps track of our current time
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKey(KeyCode.I))
            {
                Attack();

                // Modify attackRate in inspector to decide how many times player can attack per second
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("meleeAttack");

        print("Combat Attack Check!");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);

            enemy.GetComponent<EnemyStats>().TakeDmg(meleeDamage);
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
