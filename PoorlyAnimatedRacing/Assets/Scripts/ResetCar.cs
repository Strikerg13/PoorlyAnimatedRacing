using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    public roadStructure rs;

    void Start()
    {
        rs = gameObject.transform.GetComponent<roadStructure>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Reset Car"))
        {
            Transform spawnpPoint = rs.getLastSegmentPassed().transform.GetChild(0).transform;
            GameObject car = GameObject.FindGameObjectWithTag("Player");
            
            bool chkpt = spawnpPoint.GetChild(0).GetChild(0).GetComponent<Checkpoint>().isFirstSegment;
            float posModifier;

            if (chkpt)
            {
                posModifier = 2.0f;
            }
            else
            {
                posModifier = 0.0f;
            }

            car.transform.rotation = spawnpPoint.rotation;

            // place the car at the start of the last segment so we don't have issues with spawning
            // a different angle than the track piece is facing.
            car.transform.position = new Vector3(spawnpPoint.position.x + 1.0f, 
                spawnpPoint.position.y + 1.0f, 
                spawnpPoint.position.z + posModifier);

            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
