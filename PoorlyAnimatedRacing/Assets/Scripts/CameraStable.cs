using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour {

    public GameObject theCar;
    public float carX;
    public float carY;
    public float carZ;
	
	void Update () 
    {
        // get the car's rotation on each axis.
        carX = theCar.transform.eulerAngles.x;
        carY = theCar.transform.eulerAngles.y;
        carZ = theCar.transform.eulerAngles.z;

        // rotate the CameraFocusPoint in the opposite direction of the car's rotation by the same amount
        // in the x and z axis. Leave the Y because we want the camera to rotate up and down.
        transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
	}
}
