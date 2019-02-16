using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class RandomSeedGeneration : MonoBehaviour
{
    /// Seed the user submits (Format: 4-Digit Hex Number)
    public string typedSeed;
    public int numericSeed;

    public List<GameObject> UIPanelsToHide;
    public List<GameObject> UIPanelsToUnhide;
    public InputField seedDisplay;
    //public Text seedDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        // If the player pressed the button
        if (PlayerPrefs.GetString("ButtonPressed") == "yes")
        {
            // use their specified seed
            typedSeed = PlayerPrefs.GetString("MySeed");
            convertSeed(typedSeed);
            UnityEngine.Random.InitState(numericSeed);

            // Mark that the player has not pressed the button yet
            PlayerPrefs.SetString("ButtonPressed", "no");
        }
        else
        {
            // generate a new seed
            generateRandomSeed();
            convertSeed(typedSeed);
            UnityEngine.Random.InitState(numericSeed);
        }

        // Show the seed on the UI
        seedDisplay.text = typedSeed;

        GameObject.Find("TrackController").GetComponent<roadController>().StartTheGame();
    }

    /// Convert a 4-Digit hex number into an int for the random seed
    void convertSeed(string givenSeed)
    {
        // Hex Numbers: https://stackoverflow.com/questions/1139957/c-sharp-convert-to-hex-and-back-again
        numericSeed = int.Parse(givenSeed, System.Globalization.NumberStyles.HexNumber);
    }

    // This will set the typedSeed to a generated one, which the user can change before starting
    void generateRandomSeed()
    {
        typedSeed = Convert.ToInt32(UnityEngine.Random.Range(0.0f, 65535.0f)).ToString("X4");
    }

    public void setTypedSeed(string myString)
    {
        int seed = 0;
        bool checkSeed = int.TryParse(myString, out seed);

        if (!checkSeed && seed <= 65535 && seed >= 0)
        {
            typedSeed = myString;
        }
        else
        {
            return;
        }

    }

    public void letsGo()
    {
        setTypedSeed(typedSeed);

        // Save the specified seed, and mark that the player is requesting that seed.
        // PlayerPrefs Documentation: https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
        PlayerPrefs.SetString("ButtonPressed", "yes");
        PlayerPrefs.SetString("MySeed", typedSeed);

        // Restart the Scene
        GameObject.Find("ResetScript").GetComponent<Reset>().RestartLevel();
    }

    public void printPlayerPrefs()
    {
        Debug.Log("ButtonPressed = " + PlayerPrefs.GetString("ButtonPressed"));
        Debug.Log("MySeed = " + PlayerPrefs.GetString("MySeed"));
    }
}
