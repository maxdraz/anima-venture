using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public float timeScaleSlowDown;
    public GameObject rainforestInteractibles;


    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = timeScaleSlowDown;
        rainforestInteractibles.BroadcastMessage("Deactivate");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        rainforestInteractibles.BroadcastMessage("Activate");

    }
}
