using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public List<GameObject> cameras;
    int i;

    void Start ()
    {
        // turn on the 1st camera
        cameras[0].SetActive(true);

        // turn off all other cameras
        for (int i = 1; i < cameras.Count; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    void Update ()
    {
        if (Input.GetButtonDown("ChangeCamera_P1"))
        {
            if (i >= (cameras.Count - 1))
            {
                i = 0;
            }
            else
            {
                i += 1;
            }

            StartCoroutine(SwitchCamera());
        }
    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(0.01f);
        if (i < cameras.Count - 1)
        {
            cameras[i + 1].SetActive(true);
            cameras[i].SetActive(false);
        }
        else
        {
            cameras[0].SetActive(true);
            cameras[i].SetActive(false);
        }
    }
}
