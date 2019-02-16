using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraValues : MonoBehaviour
{
    /// Index of the active camera in the list of cameras.
    public int activeCamera;

    void Start()
    {
        activeCamera = PlayerPrefs.GetInt("SelectedCameraIndex");
    }
}
