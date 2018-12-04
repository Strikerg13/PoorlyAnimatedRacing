using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectionManager : MonoBehaviour {

    public void loadTrack01 ()
    {
        SceneManager.LoadScene("Track01_SinglePlayer");
    }
}
