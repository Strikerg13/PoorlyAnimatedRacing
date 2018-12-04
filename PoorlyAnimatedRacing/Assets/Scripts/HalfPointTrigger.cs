using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour {

    public GameObject LapCompleteTrigger;
    public GameObject HalfWayTrigger;

    void OnTriggerEnter ()
    {
        LapCompleteTrigger.SetActive(true);
        HalfWayTrigger.SetActive(false);
    }
}
