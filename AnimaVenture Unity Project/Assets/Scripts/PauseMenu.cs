using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public float timeScaleSlowDown;

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = timeScaleSlowDown;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
