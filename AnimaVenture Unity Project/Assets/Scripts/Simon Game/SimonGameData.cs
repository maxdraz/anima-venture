using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGameData : MonoBehaviour {

    public float currentScore;
    public float highScore = 0;
    bool newHighScoreBool = false;
    public Score_Simon score;


    private void Update()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            newHighScoreBool = true;
        }
    }

    public void saveCurrentScore()
    {
        currentScore = score.currentScore;
    }
}
