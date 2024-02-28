using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;     // Move speed
    public int startPoint;      // Starting index (pos of platform)
    public Transform[] points;      // Array of transform pts (positions where platform moves)
    
    private int i; // index of the above Array

    void Start()
    {
        // Set pos of platform to that of points using index startPoint
        transform.position = points[startPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check distance of platform and point
        // If the platform and the current point position is very close enough,
        // Update the point to the next point
        if (Vector2.Distance(transform.position, points[i].position) <0.02f)
        {
            i++;    // increase index
            if(i == points.Length)
            {
                i = 0; // Resets index if platform reaches last point
            }
        }

        // Move the platform to point position with index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
        
    }

    // private void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     // if(collision.collider.CompareTag("Player"))
    //     // {
    //     //     if(transform.position.y < collision.transform.position.y - 0.8f)
    //     //     {
    //     //         collision.transform.SetParent(transform);
    //     //     }
    //     // }

    //     collision.transform.SetParent(transform);
       
        
    // }

    // private void OnCollisionExit2D(Collision2D collision) 
    // {
    //     collision.transform.SetParent(null);
    // }
}
