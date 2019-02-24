using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navigationManager : MonoBehaviour
{
    public Queue<Direction> directions;

    public GameObject ui;
    public Image directionImage;

    /// Create a new queue of directions.
    public void initializeDirections()
    {
        directions = new Queue<Direction>();
    }
        
    /// add a direction to the navigation queue
    public void queDirection(Direction direction)
    {
        if (directions != null)
        {
            directions.Enqueue(direction);
        }
        else
        {
            initializeDirections();
            directions.Enqueue(direction);
        }

    }

    /// Advance the Navigation Queue
    public Direction nextDirection()
    {
        return directions.Dequeue();
    }

    /// Get the next Direction in the Navigation Queue without advancing the queue
    public Direction peekNextDirection()
    {
        return directions.Peek();
    }

    /// Send the next direction to the UI display
    public void displayNextDirection()
    {
        Direction dir = nextDirection();
        directionImage.sprite = dir.direction;
    }

    /// Empty the Directions Queue.
    public void clearDirections()
    {
        directions.Clear();
    }

    /// print out the current track
    public void printNavigationQueue()
    {
        // print the segments in the track
        Debug.Log("================================N=A=V=I=G=A=T=I=O=N=");
        foreach (Direction thing in directions)
        {
            Debug.Log(thing.direction.ToString());
        }
        Debug.Log("======================================");
    }
}
