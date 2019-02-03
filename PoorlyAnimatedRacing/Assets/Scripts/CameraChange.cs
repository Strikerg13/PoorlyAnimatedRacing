using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public List<GameObject> cameras;
    int i;

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
