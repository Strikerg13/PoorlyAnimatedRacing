using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class RandomSeedGeneration : MonoBehaviour
{
    /// Seed the user submits (Format: "####-###")
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

    /// Convert a 4 letter alphanumeric code into an int for the random seed
    void convertSeed(string givenSeed)
    {
        givenSeed = Regex.Replace(givenSeed, @"[^0-9]", "");
        numericSeed = Convert.ToInt32(givenSeed);
    }

    // This will set the typedSeed to a generated one, which the user can change before starting
    void generateRandomSeed()
    {
        typedSeed = Convert.ToInt32(UnityEngine.Random.Range(0.0f, 9999.0f)).ToString("0000")
        + "-"
        + Convert.ToInt32(UnityEngine.Random.Range(0.0f, 9999.0f)).ToString("0000");
    }

    public void setTypedSeed(string myString)
    {
        typedSeed = myString;
    }

    public void letsGo()
    {
        // Save the specified seed, and mark that the player is requesting that seed.
        // PlayerPrefs Documentation: https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
        PlayerPrefs.SetString("ButtonPressed", "yes");
        PlayerPrefs.SetString("MySeed", typedSeed);

        Debug.Log("The player requested a seed");
        printPlayerPrefs();

        // Restart the Scene
        GameObject.Find("ResetScript").GetComponent<Reset>().RestartLevel();


    }

    public void printPlayerPrefs()
    {
        Debug.Log("ButtonPressed = " + PlayerPrefs.GetString("ButtonPressed"));
        Debug.Log("MySeed = " + PlayerPrefs.GetString("MySeed"));
    }
}
