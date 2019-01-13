using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    // Set these directions in the Scene Editor.
    public string directions;
    public GameObject PreviousDirection;
    public GameObject NextDirection;

    public GameObject NavigationTrigger;

    void OnTriggerEnter()
    {
        PreviousDirection.GetComponent<Text>().text = NextDirection.GetComponent<Text>().text;

        NextDirection.GetComponent<Text>().text = directions;

        NavigationTrigger.SetActive(false);
    }
}
