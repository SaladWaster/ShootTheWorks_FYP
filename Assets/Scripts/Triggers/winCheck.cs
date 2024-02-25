using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCheck : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // [SerializeField]
    // GameObject textUI;


    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("You WIn!");
            // textUI.SetActive(true);
        }
    }
}
