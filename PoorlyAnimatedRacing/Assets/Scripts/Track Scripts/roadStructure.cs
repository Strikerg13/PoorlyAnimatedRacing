using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadStructure : MonoBehaviour
{
    public GameObject lastSegmentPassed;

    /// Pass in a Track Segment to have it marked as the last one the car drove through.
    public void setLastSegmentPassed(GameObject trackSegment)
    {
        lastSegmentPassed = trackSegment;
    }

    /// Call this to get back the most recent Track Segment the car drove through.
    public GameObject getLastSegmentPassed()
    {
        return lastSegmentPassed;
    }
}
