using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xp_trackgen : MonoBehaviour
{
    public GameObject trackPiece01;
    public GameObject trackPiece02;

    void Start()
    {
        trackPiece01.GetComponent<TrackSegment>().nodeStart.transform.position = 
            trackPiece02.GetComponent<TrackSegment>().nodeEnd.transform.position;

        trackPiece01.GetComponent<TrackSegment>().nodeStart.transform.rotation = 
            trackPiece02.GetComponent<TrackSegment>().nodeEnd.transform.rotation;
    }


}
