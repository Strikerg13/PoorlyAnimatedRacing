using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public bool midpoint = false;
    public bool passed = false;
    public bool isFirstSegment = false;

    void OnTriggerEnter()
    {
        // get the Track Controller
        GameObject TrackController = GameObject.Find("TrackController");
        roadStructure rs = TrackController.GetComponent<roadStructure>();

        if (midpoint)
        {
            Debug.Log("CHECKPOINT");

            roadController rc = TrackController.GetComponent<roadController>();

            rc.GenerateTrack(rc.TrackLength);
        }

        passed = true;
        rs.setLastSegmentPassed(transform.parent.parent.parent.gameObject); 
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
