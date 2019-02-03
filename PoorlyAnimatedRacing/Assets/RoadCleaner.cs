using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCleaner : MonoBehaviour {

    public Queue<GameObject> Track;
    public roadController RoadController;

    // Use this for initialization
	void Start () {
        Track = new Queue<GameObject>();
        //RoadController = this.GetComponent<roadController>();
	}

    public void QueTrackSegment(GameObject trackSegment)
    {
        if (Track != null)
        {
            Track.Enqueue(trackSegment);
        }
        else
        {
            Track = new Queue<GameObject>();
            Track.Enqueue(trackSegment);
        }
    }

    // Destroy the trailing length of track
    public void CleanUpTrack()
    {
        // Check if the track is more than double a single length so we don't delete the length we are currently on
        if (Track.Count >= (RoadController.TrackLength * 3))
        {
            GameObject segmentToDelete;

            // delete each segment in the 1st length of track in the queue
            for (int i = 1; i <= RoadController.TrackLength; i++)
            {
                segmentToDelete = Track.Dequeue();
                Destroy(segmentToDelete);
            }
        }
    }

    // print out the current track
    public void printTrackQueue()
    {
        // print the segments in the track
        Debug.Log("====================================T=R=A=C=K==");
        foreach (GameObject segment in Track)
        {
            Debug.Log(segment.name.ToString());
        }
        Debug.Log("======================================");
    }
}
