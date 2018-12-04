using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteTrigger : MonoBehaviour {

    public GameObject FinishLineTrigger;
    public GameObject HalfWayTrigger;

    public GameObject LapTimeManager;

    void OnTriggerEnter()
    {
        LapTimeManager.GetComponent<LapTimeManager>().markLap();

        // rotate active checkpoints
        FinishLineTrigger.SetActive(false);
        HalfWayTrigger.SetActive(true);
    }
}
