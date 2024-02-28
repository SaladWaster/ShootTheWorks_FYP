using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWep : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float cooldownDuration;
    public float currentCD;

    public bool coolingDown = false;

    public int maxAmmo = 10;
    private int currentAmmo;
    // public float reloadTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        currentCD = cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1"))
        if(currentAmmo > 0 && !coolingDown && Input.GetKey(KeyCode.X))
        {
            Shoot();
            coolingDown = true;
        }
        else if (currentAmmo <= 0)
        {
            Debug.Log("Out of Ammo!");
            // Reload();

            // We will implement a reload conditional if players pick up a new wep
        }

        if (coolingDown)
        {
            if (currentCD> 0)
            {
                currentCD -= Time.deltaTime;
            }
            else
            {
                coolingDown = false;   
                currentCD = cooldownDuration;           
            }
            
        }

    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("Shoot");

        currentAmmo--;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }


    // We will make this Reload occur on pick-up...
    // Implement a conditional that checks if the item the player has picked up matches a wep the player holds
    // If they match, reload
    void Reload()
    {
        Debug.Log("Reloading...");
        //currentAmmo = maxAmmo;
        
        // We will change this to top up on top of the existing Ammo...

        currentAmmo = currentAmmo + maxAmmo;
    }
}
