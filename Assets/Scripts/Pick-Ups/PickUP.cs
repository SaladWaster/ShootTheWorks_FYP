using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    //SFX audio Manager
    // AudioManager audioManager;
    
    // PlayerStats player;

    Transform player;
    //protected bool hasBeenCollected = false;




   Rigidbody2D rb; 

    private void Awake()
    {
        //player = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        // audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    public virtual void Collect()
    {
        // audioManager.PlaySound(audioManager.pickUp);
        //hasBeenCollected = true;

        PointCounter.instance.IncreasePoints(5);
        print("Item Picked!");
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        // If the drop collides with a hitbox under a "Player"
        if(col.CompareTag("Player"))
        {
            Collect();
            FindObjectOfType<AudioManager>().Play("PickUp");
            // Destroy on pick-up to prevent multiple pick-ups
            Destroy(gameObject);
            
        }

        
    }
}
