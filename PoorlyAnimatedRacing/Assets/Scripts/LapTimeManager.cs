using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

    public static int minutes;
    public static int seconds;
    public static float milliseconds;

    public GameObject txtLapTime;
    public GameObject txtBestTime;

    public float currentTime;
    public float bestTime;

    // each frame
    void Update ()
    {
        // calculate milliseconds
        milliseconds += Time.deltaTime * 10;

        // update seconds
        if (milliseconds >= 10)
        {
            milliseconds = 0;
            seconds += 1;
        }

        // update minutes
        if (seconds >= 60)
        {
            seconds = 0;
            minutes += 1;
        }

        // print the Lap Time
        txtLapTime.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("F0");

        // record the combined time parts into a variable
        currentTime = float.Parse((minutes * 60).ToString() + (seconds * 10).ToString() + milliseconds.ToString());
    }

    // Check if the time is better than the current best time.
    void updateBestTime (int min, int sec, float ms)
    {
        if ((bestTime == 0.0f) || (currentTime < bestTime))
        {
            // set the new best time.
            bestTime = currentTime;
            // display the new best time.
            txtBestTime.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00") + "." + ms.ToString("F0");
        }
    }

    // run when a lap is completed
    public void markLap()
    {
        // check if we have a new best time
        updateBestTime(minutes, seconds, milliseconds);
        // restart the lap timer
        resetLapTimer();
    }

    // reset the lap timer.
    public void resetLapTimer()
    {
        // 0 the time variables
        minutes = 0;
        seconds = 0;
        milliseconds = 0.0f;
        currentTime = 0.0f;

        // reset the textboxes
        txtLapTime.GetComponent<Text>().text = "00:00.0";
    }

    // clear the best time recorded.
    public void resetBestTime()
    {
        // clear the time variable
        bestTime = 0.0f;
        // reset the display
        txtBestTime.GetComponent<Text>().text = "00:00.0";
    }

    // clear both the Lap and Best Times
    public void resetTimes()
    {
        resetLapTimer();
        resetBestTime();
    }
}
