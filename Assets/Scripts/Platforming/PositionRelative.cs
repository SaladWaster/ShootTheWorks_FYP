using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRelative : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // if(collision.collider.CompareTag("Player"))
        // {
        //     if(transform.position.y < collision.transform.position.y - 0.8f)
        //     {
        //         collision.transform.SetParent(transform);
        //     }
        // }

        collision.transform.SetParent(transform);
       
        
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        collision.transform.SetParent(null);
    }
}
