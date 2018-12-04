using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public List<GameObject> cameras;
    int i;

	// each frame
	void Update () 
    {
        if (Input.GetButtonDown("ChangeCamera_P1"))
        {
            // if we're not at the end of the list...activate the next camera, and deactivate the current camera.
            if (i < cameras.Count - 1)
            {
                cameras[i+1].SetActive(true);
                cameras[i].SetActive(false);
                i++;
                return;
            }

            // We're at the end of the list...start over at the 0 index, and deactivate the previous camera.
            cameras[0].SetActive(true);
            cameras[i].SetActive(false);
            i = 0;
        }
	}
}
