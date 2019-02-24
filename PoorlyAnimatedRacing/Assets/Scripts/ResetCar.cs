using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCar : MonoBehaviour
{
    public roadStructure rs;
    /// Do we have enough money to reset the car?
    bool canReset;
    /// How many coins does it cost to reset the car?
    public int resetCost;
    /// Image to display that we cannot reset the car.
    public GameObject noReset;

    void Start()
    {
        rs = gameObject.transform.GetComponent<roadStructure>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Reset Car") || Input.GetAxis("Reset_Car") == -1f)
        {
            canReset = GameObject.Find("GameManager").GetComponent<MoneyDisplay>().removeCoins(resetCost);

            // If we don't have the money, don't allow a reset.
            if (!canReset)
            {
                StartCoroutine(denyReset());
                return;
            }

            // get the nodeStart of the track segment so the car starts at the beginning of the segement
            // and they can't spam reset to advance the car.
            Transform spawnpPoint = rs.getLastSegmentPassed().GetComponent<TrackSegment>().respawnPoint;
            GameObject car = GameObject.FindGameObjectWithTag("Player");

            // move the car forward a little so the car doesn't fall backwards of the segment of track.
            //bool chkpt = rs.GetComponent<Checkpoint>().isFirstSegment;
            //float posModifier = 2.0f;

            car.transform.rotation = spawnpPoint.rotation;

            // place the car at the location of the Track Segment's designated Spawn Point.
            car.transform.position = spawnpPoint.position;

            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    IEnumerator denyReset()
    {
        noReset.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        noReset.SetActive(false);

    }
}
