using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown("Reset"))
        {
            // https://stackoverflow.com/questions/41644156/unity3d-reset-current-scene/41644224
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
