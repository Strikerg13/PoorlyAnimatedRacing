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
        generateRandomSeed();
        seedDisplay.text = typedSeed;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && typedSeed != null)
        {
            letsGo();
        }
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
        convertSeed(typedSeed);
        UnityEngine.Random.InitState(numericSeed);

        GameObject.Find("TrackController").GetComponent<roadController>().StartTheGame();

        foreach (GameObject panel in UIPanelsToHide)
        {
            panel.SetActive(false);
        }

        foreach (GameObject panel in UIPanelsToUnhide)
        {
            panel.SetActive(true);
        }
    }
}
