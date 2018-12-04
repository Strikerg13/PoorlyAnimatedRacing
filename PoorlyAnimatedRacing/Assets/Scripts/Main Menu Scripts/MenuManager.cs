using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	
    public void loadStageSelectionMenu()
    {
        SceneManager.LoadScene("StageSelectMenu");
    }

    public void quitToDesktop ()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
