using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingScript : MonoBehaviour
{
    public float damage = 1;
    //public Rigidbody2D rb;

    // public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats playerGuy = hitInfo.GetComponent<PlayerStats>();

        if(playerGuy != null)
        {
            //playerGuy.TakeDmg(damage);
            Debug.Log("Player is hit!");
        }
             
        
        // ONLY ADD THIS LATER, IT'S JUST A HIT EFFECT
        // Instantiate(impactEffect, transform.position, transform.rotation);
        
        // Debug.Log(hitInfo.name);
        // Destroy(gameObject);
    }
}
