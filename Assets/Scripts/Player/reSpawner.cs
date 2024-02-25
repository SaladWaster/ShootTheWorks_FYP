using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reSpawner : MonoBehaviour
{
    [SerializeField]
    public float yLimit;

    [SerializeField]
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Respawn();
    }

    void Respawn()
    {
        if(transform.position.y < yLimit)
        {
            transform.position = spawnPoint.position;
        }
    }
}
