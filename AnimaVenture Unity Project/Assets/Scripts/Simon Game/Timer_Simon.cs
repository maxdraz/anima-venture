using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Simon : MonoBehaviour {

    [SerializeField]Text timerText;
    public float time = 120;
    public bool startTimerBool;


    private void Update()
    {
        
        DisplayTimer();

        if(startTimerBool)
        {
            StartTimer();
        }

    }

    public void StartTimer()
    {
        time -= Time.deltaTime;

        if (time <= 0)
            time = 0;
    }

    void DisplayTimer()
    {
        timerText.text = Mathf.RoundToInt(time).ToString();
    }

   public void SubtractTime(float t)
    {
        time -= t;
    }

}
