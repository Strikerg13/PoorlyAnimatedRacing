using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public List<GameObject> cameras;
    int i;

    void Start ()
    {
        // Check if a camera was set last time, otherwise turn on the 1st camera
        int savedCamera = GameObject.Find("GameManager").GetComponent<CameraValues>().activeCamera;
        if (savedCamera >= 0 && savedCamera < cameras.Count)
        {
            setActiveCamera(cameras, savedCamera);
        }
        else
        {
            setActiveCamera(cameras, 0);
        }


        // turn off all other cameras
        for (int i = 0; i < cameras.Count; i++)
        {
            // don't shut off our saved camera!
            if (i != savedCamera)
            {
                setInactiveCamera(cameras, i);
            }

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

    /// Pass in the list of cameras and the index in that list with the camera you want to switch to.
    void setActiveCamera(List<GameObject> cams, int index)
    {
        cams[index].SetActive(true);
        GameObject.Find("GameManager").GetComponent<CameraValues>().activeCamera = index;

    }

    /// Pass in the list of cameras and the index in that list with the camera you want to switch from.
    void setInactiveCamera(List<GameObject> cams, int index)
    {
        cams[index].SetActive(false);
    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(0.01f);
        if (i < cameras.Count - 1)
        {
            setActiveCamera(cameras, i + 1);
            setInactiveCamera(cameras, i);
        }
        else
        {
            setActiveCamera(cameras, 0);
            setInactiveCamera(cameras, i);
        }
    }
}
