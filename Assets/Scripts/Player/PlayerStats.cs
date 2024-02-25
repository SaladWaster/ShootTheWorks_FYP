using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
        public float health = 100;

        public float maxHealth;

        public Image healthBar;

        public float lives = 3;

        // DMG Flash
        [SerializeField] 
        private DamageFlash flashEffect;

        // Max fall distance before respawn
        [SerializeField]
        public float yLimit;

        // Respawn position
        [SerializeField]
        private Transform spawnPoint;

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

    void FixedUpdate()
    {
        // Checks if player has fallen off the map
        if(transform.position.y < yLimit)
        {
            Die();
        }
    }


    // Notice how we assign public to the TakeDmg function
    // This is only used when we want to call this function
    // In another script
    // In this case, this function will be called from the Bullet script
    public void TakeDmg(float dmg)
    {
        health -= dmg;

        flashEffect.Flash();

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);

        lives--;

        if(lives > 0)
        {
            Respawn();

            Debug.Log("Respawning");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Player is ded");
        }

        
    }

    void Respawn()
    {
        
        health = maxHealth;

        transform.position = spawnPoint.position;
    }

    public void SetSpawnPoint(Transform newSpawnPos)
    {
        spawnPoint = newSpawnPos;
    }
}
