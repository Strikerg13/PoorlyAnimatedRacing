using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    /// Add a Cube Mesh Filter & Renderer and copy the nodeEnd's values to it. 
    /// Then use the Parent object here as the point where the track segment starts.  
    /// 
    /// NOTE: This object must be the parent object of everything else, so the rest of the
    /// track segment moves and rotates with this node. This is used to overlay the track segments
    /// when they are spawned into the world.
    public Transform nodeStart;

    /// the node marking where the track segment ends
    public Transform nodeEnd;

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

    /// Point on the track segment the car will respawn at.
    public Transform respawnPoint;
}
