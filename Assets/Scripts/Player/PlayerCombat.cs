using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    // public LayerMask enemyLayers;

    public float meleeDamage = 50;

    // No. of times player can attack (per second)
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {

        // Time.time keeps track of our current time
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKey(KeyCode.Z))
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

        FindObjectOfType<AudioManager>().Play("Melee");

        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach(Collider2D enemy in hitEnemies)
        {

            EnemyStats badGuy = enemy.GetComponent<EnemyStats>();
            Breakable breakObject = enemy.GetComponent<Breakable>();

            if(badGuy != null)
            {
                badGuy.TakeDmg(meleeDamage);
            }
            else if(breakObject != null)
            {
                breakObject.TakeDmg(meleeDamage);
            }

            Debug.Log("We hit" + enemy.name);

            //enemy.GetComponent<EnemyStats>().TakeDmg(meleeDamage);


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
