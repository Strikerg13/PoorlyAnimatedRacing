using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCountManager : MonoBehaviour {

    public int numberOfLaps;
    public int currentLap;

    public GameObject txtLapCount;
    public GameObject FinishCamera;

	// When the Lap Manager object is created
	void Start () 
    {
        // start us on the 1st lap
        currentLap = 1;
        // update the display to "lap 1 of x"
        txtLapCount.GetComponent<Text>().text = currentLap.ToString() + " / " + numberOfLaps.ToString();
	}

    // Increment the current lap, end the race if we just finished the last lap...otherwise update the count display.
    public void nextLap()
    {
        currentLap += 1;
        if (checkEndOfRace())
        {
            raceFinished();
            return;
        }

        txtLapCount.GetComponent<Text>().text = currentLap.ToString() + " / " + numberOfLaps.ToString();
    }

    // Did we just complete the last lap of the race?
    bool checkEndOfRace()
    {
        if (currentLap > numberOfLaps)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // The race is over...do stuff
    void raceFinished()
    {
        FinishCamera.SetActive(true);
    }
}
