using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    /// the node marking where the track segment starts   
    public GameObject nodeStart;
    /// the node marking where the track segment ends
    public GameObject nodeEnd;
    /// the actual model with the surface of the road
    public GameObject roadSurface;
    /// the box collider used as the track segment's trigger. 
    /// This should be attached to the path or curve object in the road surface model
    public BoxCollider roadTrigger;
    /// the script that stores data about the car's interacting with this Track Segment.
    /// The Checkpoint script needs to be attached to the object that has the box collider
    /// being used as the Road Trigger, and a reference to it needs to be here so the generator
    /// can change values on it.
    public Checkpoint checkpoint;
}
