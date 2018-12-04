using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCompleteTrigger : MonoBehaviour {

    public GameObject FinishLineTrigger;
    public GameObject HalfWayTrigger;

    public GameObject LapManager;

    void OnTriggerEnter()
    {
        LapManager.GetComponent<LapTimeManager>().markLap();
        LapManager.GetComponent<LapCountManager>().nextLap();

        // rotate active checkpoints
        FinishLineTrigger.SetActive(false);
        HalfWayTrigger.SetActive(true);
    }
}
