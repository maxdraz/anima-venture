using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Simon : MonoBehaviour {
    [SerializeField] int score = 0;
    public int currentScore = 0;
    // [SerializeField] Text scoreText;
    [SerializeField] TextMesh scoreText;
    public ParticleSystem ps;


    public IEnumerator Add(int amount)
    {
        
        if(score == 0)
        {
            yield return new WaitForSeconds(1.75f);
        }else
        {
            yield return new WaitForSeconds(0.75f);
        }

        //yield return new WaitForSeconds(0.25f);
        scoreText.gameObject.SetActive(true);

        score += amount;
        currentScore = score;
        UpdateDisplay();
        
        ps.gameObject.SetActive(true);
        ps.Play();
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
