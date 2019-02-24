using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePath : MonoBehaviour
{
    /// Add the next couple Track Segments to this queue in the prefab.
    /// When the trigger is activated, the main track queue will be dumped to the 
    /// cleaner, and then be set equal to this queue, effectively making it
    /// the new main track queue.
    public Queue alternateQueue;

    /// The next set of track segments for the alternateQueue.
    public List<GameObject> trackSegments;

}
