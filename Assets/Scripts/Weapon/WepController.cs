using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce; // Pierce is hits before a wep breaks


    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        print("I am attacking!");
        currentCooldown  = cooldownDuration;
        
    }



}
