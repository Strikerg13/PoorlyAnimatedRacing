using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {



    void OnTriggerEnter()
    {
        Debug.Log("CHECKPOINT");

        // get the Track Controller
        GameObject TrackController = GameObject.Find("TrackController");


        TrackController.GetComponent<roadController>().GenerateTrack(5);


        this.GetComponent<BoxCollider>().enabled = false;
    }
}
