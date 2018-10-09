using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Simon : MonoBehaviour {
    [Header("Variables for Designer")]
    [SerializeField] float startDelay = 2f;
    [SerializeField] int maxSequenceLength;
    
    //An array to store telegraphs
    [SerializeField] Telegraph_Simon[] telegraphs;

    //create a list to store colour sequence
    [SerializeField] List<int> colourSequence;

    GameObject startButton;
    GameObject restartButton;

    private void Awake()
    {
        //initialize all references
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);

        //colourSequence.Count = colourSequenceLength;
    }

    void Start () {
        Debug.Log(gameObject.name + ": Welcome! Press 'Start' to play");
    }
	
	// Update is called once per frame
	void Update () {
        if(colourSequence.Count > maxSequenceLength)
        {
            // Restart Game
        }
	}

    public void StartGame()
    {
        //make start button disappear       
        startButton.SetActive(false);
        //make restart button appear        
        restartButton.SetActive(true);
        // invoke pick random colour method
        Invoke("PickRandomColour", startDelay);
        

    }

    void PickRandomColour()
    {
        int randomColourIndex = Random.Range(0, telegraphs.Length);
        //display telegraph
        telegraphs[randomColourIndex].DisplayTelegraph();
        
        colourSequence.Add(randomColourIndex);
    }

    public void RestartGame()
    {
        //delete previous colour sequence
        colourSequence.Clear();
        //call start game function
        restartButton.SetActive(false);
        startButton.SetActive(true);        
    }
}
