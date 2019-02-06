using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadStructure : MonoBehaviour
{
    public GameObject lastSegmentPassed;

    public void setLastSegmentPassed(GameObject trackSegment)
    {
        lastSegmentPassed = trackSegment;
    }

    public GameObject getLastSegmentPassed()
    {
        return lastSegmentPassed;
    }
}
