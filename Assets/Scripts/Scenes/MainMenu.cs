using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit the Game!");
        Application.Quit();
    }
}
