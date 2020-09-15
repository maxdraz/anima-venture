using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public float timeScaleSlowDown;
    public GameObject rainforestInteractibles;


    public void TogglePauseMenu()
    {
        rainforestInteractibles.BroadcastMessage("Deactivate");
        pauseMenu.SetActive(true);
        Time.timeScale = timeScaleSlowDown;
        
    }

    public void Resume()
    {
        rainforestInteractibles.BroadcastMessage("Activate");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
}
