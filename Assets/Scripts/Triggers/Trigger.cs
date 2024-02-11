using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public bool oneShot = false;
    private bool alreadyEntered = false;
    private bool alreadyExited = false;

    public string tagFilter;

    public UnityEvent onTriggerEnter;

    public UnityEvent onTriggerExit;
    
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(alreadyEntered)
        {
            return;
        }

        // Only Trigger if the correct tag collides with the trigger
        if (!string.IsNullOrEmpty(tagFilter) && !collision.CompareTag(tagFilter))
        {
            return;
        }

        onTriggerEnter.Invoke();

        if(oneShot)
        {
            alreadyEntered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) 
    {

        if(alreadyExited)
        {
            return;
        }

        // Only Trigger if the correct tag collides with the trigger
        if (!string.IsNullOrEmpty(tagFilter) && !collision.CompareTag(tagFilter))
        {
            return;
        }

        onTriggerExit.Invoke();

        if(oneShot)
        {
            alreadyExited = true;
        }
    }
}
