using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Simon : MonoBehaviour {

    [SerializeField]Text timerText;
    public float time = 120;

    

    private void Update()
    {
        StartTimer();
        DisplayTimer();

    }

    void StartTimer()
    {
        time -= Time.deltaTime;        
    }

    void DisplayTimer()
    {
        timerText.text = Mathf.RoundToInt(time).ToString();
    }

}
