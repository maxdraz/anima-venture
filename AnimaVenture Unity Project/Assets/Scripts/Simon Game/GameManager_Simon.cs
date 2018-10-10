using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Simon : MonoBehaviour {
    [Header("Tweakable Variables")]
    [SerializeField] float gameStartDelay = 2f;
    [SerializeField] float delayBetweenTelegraphs=2f;
    [SerializeField] int maxSequenceLength;

    [Space(30)]
    [Header("Sequence, Telegraphs, Buttons")]
    //create a list to store colour sequence
    [SerializeField]
    List<int> colourSequence;
    int positionInSequence= 0;
    //An array to store telegraphs
    [SerializeField]
    Telegraph_Simon[] telegraphs;
    [SerializeField]
    Button_Simon[] buttons;

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
        
        //Assign each button its index in the array
        SetButtonIndex();
    }
	
	// Update is called once per frame
	void Update () {

        if (colourSequence.Count > maxSequenceLength)
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
        Invoke("PickRandomColour", gameStartDelay);
        

    }

    IEnumerator PlayGame()
    {
        //make start button disappear       
        startButton.SetActive(false);
        //make restart button appear        
        restartButton.SetActive(true);
        //reset the current input position in sequence
        positionInSequence = 0;
        yield return new WaitForSeconds(delayBetweenTelegraphs);
        //Play back sequence
        foreach(int colourIndex in colourSequence)
        {
            //whatever colour is stored in the list, display the corresponding telegraph
            telegraphs[colourIndex].DisplayTelegraph();
            yield return new WaitForSeconds(delayBetweenTelegraphs);
        }
        //pick a new random colour and add it to the list
        PickRandomColour();
    }

    void SetButtonIndex()
    {
        for(int cnt = 0; cnt < buttons.Length; cnt++)
        {
            buttons[cnt].ButtonIndex = cnt;
        }
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

    public void ButtonPressed(int buttonIndex)
    {
        Debug.Log("Button " + buttonIndex + " was pressed");

        if (colourSequence[positionInSequence] == buttonIndex)
        {
            Debug.Log("Correct button pressed!");
            //add 1 to the current position in the sequence
            positionInSequence++;
            //if the current position has reached the end of the recorded sequence
            if (positionInSequence == colourSequence.Count)
            {
                //replay sequence and add a new colour to the end
                StartCoroutine(PlayGame());
            }
        }
        else
        {
            Debug.Log("Wrong! Try again");
            //restart game
            RestartGame();
        }
        
    }
}
