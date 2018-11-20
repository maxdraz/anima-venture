using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour {

    public static GamePauser sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
    }

    public void PauseForSeconds(float t)
    {
        StartCoroutine(PauseForTime(t));
    }

    public IEnumerator PauseForTime(float t)
    {
       
            Time.timeScale = 0f;
            yield return new WaitForSeconds(t);
            Time.timeScale = 1f;
            
        
        
    }
}
