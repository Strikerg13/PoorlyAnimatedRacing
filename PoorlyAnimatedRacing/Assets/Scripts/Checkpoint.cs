using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {



    void OnTriggerEnter()
    {
        Debug.Log("CHECKPOINT");

        // get the Track Controller
        GameObject TrackController = GameObject.Find("TrackController");

        roadController rc = TrackController.GetComponent<roadController>();

        rc.GenerateTrack(rc.TrackLength);


        this.GetComponent<BoxCollider>().enabled = false;
    }
}
