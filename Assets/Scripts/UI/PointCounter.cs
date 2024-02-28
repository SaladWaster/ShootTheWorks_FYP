using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public static PointCounter instance;

    public TMP_Text pointText;
    public TMP_Text gameOverText;
    public TMP_Text resultsText;
    public TMP_Text timeText;
    public int currentPoints = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "SCORE: " + currentPoints.ToString();
        resultsText.text = currentPoints.ToString();
        gameOverText.text = currentPoints.ToString();
        timeText.text = "Bonus Time Score: " + currentPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePoints(int value)
    {
        currentPoints += value;
        pointText.text = "SCORE: " + currentPoints.ToString();
        resultsText.text = currentPoints.ToString();
        gameOverText.text = currentPoints.ToString();

    }

    public void IncreaseTimePoints(int value)
    {
        currentPoints += value;
        timeText.text = "Bonus Time Score: " + currentPoints.ToString();
        Debug.Log("Counter Time left: " + currentPoints);
    }
}
