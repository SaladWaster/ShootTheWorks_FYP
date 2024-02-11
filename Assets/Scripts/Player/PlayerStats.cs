using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
        public float health = 100;

        public float maxHealth;

        public Image healthBar;

    // public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }


    // Notice how we assign public to the TakeDmg function
    // This is only used when we want to call this function
    // In another script
    // In this case, this function will be called from the Bullet script
    public void TakeDmg(float dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);

        Debug.Log("Player is ded");
    }
}
