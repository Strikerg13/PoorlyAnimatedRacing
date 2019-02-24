using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePath : MonoBehaviour
{
    /// The next set of track segments for the alternateQueue.
    /// 
    /// NOTE: Directions will be activated in the order that
    /// they have in this list.
    public List<GameObject> trackSegments;

    public bool passed = false;

    /// Put the last segment of the alt path here so it 
    /// can be passed in as the Last Segment Passed 
    /// in the roadController.
    public GameObject parentSegment;

    void OnTriggerEnter()
    {
        // get the Track Controller
        GameObject TrackController = GameObject.Find("TrackController");
        roadStructure rs = TrackController.GetComponent<roadStructure>();

        // get the Navigation Controller
        GameObject navController = GameObject.Find("NavigationController");
        navigationManager nav = navController.GetComponent<navigationManager>();

        roadController rc = TrackController.GetComponent<roadController>();

        // Shift the road generation to our alternate path.
        rc.setTrackSegment02(parentSegment);

        // Dump the current navigation and set it to start with our new path.
        nav.initializeDirections();
        foreach (GameObject trackSegment in trackSegments)
        {
            nav.queDirection(trackSegment.GetComponent<Direction>());
        }
        nav.displayNextDirection();

        // Generate the next set of track on the alt path.
        rc.GenerateTrack(rc.TrackLength);

        // Mark that we've reached this segment for the car reset functionality.
        passed = true;
        rs.setLastSegmentPassed(parentSegment); 

        // We're done with this trigger...shut it off.
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

}
