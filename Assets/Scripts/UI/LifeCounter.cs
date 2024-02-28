using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    public static LifeCounter instance;

    public TMP_Text lifeText;
    public int currentLives= 3;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "LIVES: " + currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseLives(int value)
    {
        currentLives -= value;
        lifeText.text = "LIVES: " + currentLives.ToString();
    }
}
