using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Simon : MonoBehaviour {
    [SerializeField] int score = 0;
    public int currentScore = 0;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    public void Add(int amount)
    {
        score += amount;
        currentScore = score;
        UpdateDisplay();
    }

    public void Set(int amount)
    {
        score = amount;
        UpdateDisplay();
    }
    
    void UpdateDisplay()
    {
        scoreText.text = score.ToString();
    }
}
