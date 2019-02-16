using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool isPaused = false;

    // Automatically unpause the game when the scene resets
    void Start()
    {
        unpauseTheGameManually();
    }

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


    /// Cycles between paused & unpaused game states
    public void pauseTheGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    /// Forces game to unpause, regardless of current pause state
    public void unpauseTheGameManually()
    {
        Time.timeScale = 1;
        isPaused = true;
    }

    /// Forces game to pause, regardless of current pause state
    public void pauseGameManually()
    {
        Time.timeScale = 0;
        isPaused = false;
    }

    /// Quit to desktop
    public void exitTheGame()
    {
        // Make sure we clear the seed variables for the next time they play
        PlayerPrefs.SetString("ButtonPressed", "no");
        PlayerPrefs.SetString("MySeed", "none");
        PlayerPrefs.SetInt("SelectedCameraIndex", 0);

        Debug.Log("Program Terminated...");
        Application.Quit();
    }
}
