using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class roadController : MonoBehaviour {

    public int TrackLength; 

    GameObject TrackSegment01;
    GameObject TrackSegment02;

    public GameObject Car;

    public List<GameObject> TrackSegments;

    public RoadCleaner roadCleaner;

    void Start()
    {
        //roadCleaner = roadController.GetComponent<RoadCleaner>();

        // create the 1st track segment
        InitializeTrack();

        // place the car on the 1st track segment
        Instantiate(Car, new Vector3(TrackSegment01.transform.position.x, TrackSegment01.transform.position.y + 0.5f, TrackSegment01.transform.position.z + 5.0f), TrackSegment01.transform.rotation);

        // create a length of track.
        GenerateTrack(TrackLength);

    }

    // start a track with 2 line 100 segments
    void InitializeTrack()
    {
        TrackSegment01 = CreateTrackSegment();
        TrackSegment02 = null;

        // add segment to the track for later cleanup
        roadCleaner.QueTrackSegment(TrackSegment01);
    }

    void LoadNextSegment()
    {
        if (TrackSegment02 != null)
        {
            // Make the 2nd track segment into the 1st track segment
            TrackSegment01 = TrackSegment02;

            // instantiate a new track segment at the same position as Segment 01, and assign as Track Segment 02
            TrackSegment02 = CreateTrackSegment(TrackSegment01);

            // move the new track segment so it connects with the end of the previous track segment
            OverlayTrackSegments(TrackSegment01, TrackSegment02);
        }
        else
        {
            // instantiate a new track segment at the same position as Segment 01, and assign as Track Segment 02
            TrackSegment02 = CreateTrackSegment(TrackSegment01);

            // move the new track segment so it connects with the end of the previous track segment
            OverlayTrackSegments(TrackSegment01, TrackSegment02);
        }
    }


    // create a new track segment and store it in the given Game Object
    GameObject CreateTrackSegment()
    {
        return (GameObject)Instantiate(GetSpecificTrackSegmentFromList("Line 100"), new Vector3(0,0,0), Quaternion.identity);
    }

    // create a new track segment at the location of the Previous Track Segment and store it in the given Game Object
    GameObject CreateTrackSegment(GameObject PreviousTrackSegment)
    {
        return (GameObject)Instantiate(GetRandomTrackSegmentFromList(TrackSegments), 
                                       PreviousTrackSegment.transform.position, 
                                       PreviousTrackSegment.transform.rotation);
    }

    // pulls out a track segment with the given name from the list of track segments. 
    GameObject GetSpecificTrackSegmentFromList(string name)
    {
        return TrackSegments.Where(GameObject => (GameObject != null && GameObject.name == name)).SingleOrDefault();
    }

    // pulls out a random track segment from the given list.
    GameObject GetRandomTrackSegmentFromList(List<GameObject> TrackSegments)
    {
        GameObject randomTrackSegment = null;
        int randomIndex;

        // keep trying until we get an actual piece of track.
        while (randomTrackSegment == null)
        {
            // pick a random number within the indexes of the list.
            randomIndex = (int)Random.Range(0.0f, (TrackSegments.Count - 1) * 1.0f);

            randomTrackSegment = TrackSegments.ElementAt(randomIndex);
        }

        return randomTrackSegment;
    }

    // Joins two segments of track together.
    void OverlayTrackSegments(GameObject PreviousTrackSegment, GameObject NextTrackSegment)
    {
        // get the nodeEnd of the 1st track segment and the nodeStart of the 2nd track segment
        Transform transPrevious = PreviousTrackSegment.transform.Find("nodeStart").Find("nodeEnd");
        Transform transNext = NextTrackSegment.transform.Find("nodeStart");

        // lay the start of the 2nd track segment over the end of the 1st track segment
        NextTrackSegment.transform.rotation = transPrevious.rotation;
        transNext.position = transPrevious.position;
    }

    // create a new length of track
    public void GenerateTrack(int TrackLength)
    {
        for (int i = 1; i <= TrackLength; i++)
        {
            LoadNextSegment();

            // if this is the midpoint, set the trigger
            if (i == (TrackLength / 2))
            {
                TrackSegment02.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
            }

            // add this segment to the Track queue for later cleanup
            roadCleaner.QueTrackSegment(TrackSegment02);
        }
        roadCleaner.CleanUpTrack();
    }
}
