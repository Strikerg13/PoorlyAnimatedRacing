using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Pause_Game"))
        {
            pauseTheGame();
        }

        if (Input.GetButtonDown("Quit"))
        {
            exitTheGame();
        }

    }

    public void pauseTheGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void exitTheGame()
    {
        Debug.Log("Program Terminated...");
        Application.Quit();
    }
}
