using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Simon : MonoBehaviour {
    [Header("Tweakable Variables")]
    [SerializeField] float gameStartDelay = 2f;
    [SerializeField] float delayBetweenTelegraphs=2f; 
    [SerializeField] float timerTime;
    [SerializeField] float timeToSubtract;

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

    [Space(15)]
    [SerializeField] Score_Simon score;
    [SerializeField] Timer_Simon timer;


    private void Awake()
    {
        //initialize all references
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
        //score = GameObject.Find("Score").GetComponent<Score_Simon>();

        //colourSequence.Count = colourSequenceLength;
    }

    void Start () {
        Debug.Log(gameObject.name + ": Welcome! Press 'Start' to play");
        //Set the timer 
        timer.time = timerTime;
        //Assign each button its index in the array
        SetButtonIndex();
    }
	
	// Update is called once per frame
	void Update () {

        if (timer.time <= 0)
        {
            GameEnd();
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
        Debug.Log("play game function called");
        //make start button disappear       
        startButton.SetActive(false);
        //make restart button appear        
        restartButton.SetActive(true);
        //reset the current input position in sequence
        positionInSequence = 0;
        yield return new WaitForSeconds(delayBetweenTelegraphs);
        //Play back sequence
        foreach (int colourIndex in colourSequence)
        {
            //whatever colour is stored in the list, display the corresponding telegraph
            telegraphs[colourIndex].DisplayTelegraph();
            yield return new WaitForSeconds(delayBetweenTelegraphs);
        }
        //pick a new random colour and add it to the list
        PickRandomColour();

    }

    IEnumerator PlayBackSequence()
    {
        yield return new WaitForSeconds(delayBetweenTelegraphs);

        positionInSequence = 0;

        foreach(int colourIndex in colourSequence)
        {
            //whatever colour is stored in the list, display the corresponding telegraph
            telegraphs[colourIndex].DisplayTelegraph();
            yield return new WaitForSeconds(delayBetweenTelegraphs);
        }
        //enable buttons again
        EnableButtons();
    }

    void DisableButtons()
    {
        Debug.Log("Disable buttons method called  " + buttons.Length);
        //disable colliders on buttons to prevent player input
        for (int cnt = 0; cnt < buttons.Length; cnt++)
        {
            buttons[cnt].GetComponent<CircleCollider2D>().enabled = false;
           

        }
    }

    void EnableButtons()
    {
        Debug.Log("Enable buttons called");
        for (int cnt = 0; cnt < buttons.Length; cnt++)
        {
            buttons[cnt].GetComponent<CircleCollider2D>().enabled = true;
        }
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

        //Enable Buttons here
        EnableButtons();
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
                //Add one to score
                score.Add(1);
                //Subtract time from timer
                timer.SubtractTime(timeToSubtract);
                //replay sequence and add a new colour to the end
                DisableButtons();
                StartCoroutine(PlayGame());
            }
        }
        else
        {
            //disable buttons
            DisableButtons();

            Debug.Log("Wrong! Try again");
            //restart game
            //RestartGame();
            //set score to be current score
            score.Set(score.currentScore);
            //Play back sequence
            StartCoroutine(PlayBackSequence());
        }       
        
    }

    void GameEnd()
    {
        // if timer reaches 0:
        // - enable menu object

        // disable buttons
        DisableButtons();

        //disable telegraphs
        DisableTelegraphs();
    }

    void DisableTelegraphs()
    {
        for(int cnt = 0; cnt < telegraphs.Length; cnt ++)
        {
            telegraphs[cnt].ResetTelegraph();
        }
    }
}
