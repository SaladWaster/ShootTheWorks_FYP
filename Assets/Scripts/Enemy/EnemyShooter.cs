using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timer;
    private GameObject player;

    public EnemyMovement eMove;

    public float shootCD;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;

        // float distance = Vector2.Distance(transform.position, player.transform.position)

        // if(timer > 2)
        // {
        //     timer = 0;
        //     Shoot();
        // }

        if(eMove.atkPlayer)
        {
            timer += Time.deltaTime;

            if(timer > shootCD)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        animator.SetTrigger("EnemyShoot");

        print("Enemy Shoot Check!");
        
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
    }
}
