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

        [SerializeField]
        GameObject endScreen;

        // SHADOW I-FRAMES????!!!
        [Header("I-Frames")]
        public float invincibilityDuration;
        float invincibilityTimer;
        bool isInvincible;



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

        // Repeatedly check invincibility timer
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        // We use else if to double check if the player is invincible when timer hits 0
        // Before we set isInvincible back to false
        else if (isInvincible)
        {
            isInvincible = false;
        }

        // Checks if player has fallen off the map
        if(transform.position.y < yLimit)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        
    }


    // Notice how we assign public to the TakeDmg function
    // This is only used when we want to call this function
    // In another script
    // In this case, this function will be called from the Bullet script
    public void TakeDmg(float dmg)
    {


        // If player is not invincible, take damage and gain i-frames
        if(!isInvincible)
        {

            health -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            flashEffect.Flash();

            if(health <= 0)
            {
                Die();
            }
        }
        
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);

        lives--;

        LifeCounter.instance.DecreaseLives(1);

        if(lives > 0)
        {
            Respawn();

            Debug.Log("Respawning");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Player is ded");

            GameOver();
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

    void GameOver()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
        FindObjectOfType<AudioManager>().Play("GameOver");
        Time.timeScale = 0f; // <- It will stop your game time. use it if you need it.
        endScreen.SetActive(true); // <- Show GameOver Panel

    }
}
