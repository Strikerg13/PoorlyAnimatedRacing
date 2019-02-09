using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject car;
    int velocity;

    public Text speedDisplay;

    void Start()
    {
        StartCoroutine("FindPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            velocity = (int)car.GetComponent<Rigidbody>().velocity.magnitude;
            speedDisplay.text = velocity.ToString();
        }
    }

    private IEnumerator FindPlayer()
    {
        while (GameObject.FindGameObjectWithTag("Player") == null)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("CAR not found.");
        }

        car = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("I found the PLAYER!!!!");
    }
}
