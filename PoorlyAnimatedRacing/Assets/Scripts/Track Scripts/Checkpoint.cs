using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public bool midpoint = false;
    public bool passed = false;
    public bool isFirstSegment = false;

    /// Put the parent game object here so the 
    /// entire track segment can be passed in as the 
    /// Last Segment Passed in the roadController.
    public GameObject segmentTransform;

    void OnTriggerEnter()
    {
        // get the Track Controller
        GameObject TrackController = GameObject.Find("TrackController");
        roadStructure rs = TrackController.GetComponent<roadStructure>();

        // get the Navigation Controller
        GameObject navController = GameObject.Find("NavigationController");
        navigationManager nav = navController.GetComponent<navigationManager>();

        if (midpoint)
        {
            Debug.Log("CHECKPOINT");

            roadController rc = TrackController.GetComponent<roadController>();

            rc.GenerateTrack(rc.TrackLength);
        }

        passed = true;
        rs.setLastSegmentPassed(segmentTransform); 
        nav.displayNextDirection();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
