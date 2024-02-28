using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCheck : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    //public GameObject endScreen;

    // [SerializeField]
    // GameObject textUI;

    [SerializeField]
    GameObject endScreen;
    
    [SerializeField]
    Timer myTimer;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("You WIn!");
            // textUI.SetActive(true);

            Results();
        }
    }

    void Results()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
        FindObjectOfType<AudioManager>().Play("Winner");
        Time.timeScale = 0f; // <- It will stop your game time. use it if you need it.
        myTimer.TimeScore(Mathf.FloorToInt(myTimer.timeRemaining));
        endScreen.SetActive(true); // <- Show Results Panel
    }
}
