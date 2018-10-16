using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Simon : MonoBehaviour {
    [Header("Tweakable Variables")]
    [SerializeField] float gameStartDelay = 2f;
    [SerializeField] float delayBetweenTelegraphs=1.5f; 
    [SerializeField] float timerTime;
    [SerializeField] float timeToSubtract;
    [SerializeField] float telegraphLightUpTime = 1.5f;

    [Space(15)]
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
    [Header("Score and Timer")]
    [SerializeField] Score_Simon score;
    [SerializeField] Timer_Simon timer;
    [SerializeField] GameObject endGameMenu;
    [Space(15)]
    [Header("Animations")]
    //Animations
    [SerializeField] Animator animator;


    private void Awake()
    {
        //initialize all references
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
        
        //score = GameObject.Find("Score").GetComponent<Score_Simon>();

        //colourSequence.Count = colourSequenceLength;
    }

    void Start () {
        
        //Disable end game menu object
        endGameMenu.SetActive(false);
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
        //call start timer function
        timer.startTimerBool = true;
        //make restart button appear        
       // restartButton.SetActive(true);
        // invoke pick random colour method
        Invoke("PickRandomColour", gameStartDelay);
        

    }

    IEnumerator PlayGame()
    {
       
        //make start button disappear       
        startButton.SetActive(false);
        //make restart button appear        
        //restartButton.SetActive(true);
        //reset the current input position in sequence
        positionInSequence = 0;
        yield return new WaitForSeconds(delayBetweenTelegraphs);
        //Play back sequence
        foreach (int colourIndex in colourSequence)
        {
            //if timer is 0, stop playing sequence if it's in progress
            if(timer.time <= 0)
            {
                yield break;

            }
            //whatever colour is stored in the list, display the corresponding telegraph
            StartCoroutine(telegraphs[colourIndex].DisplayTelegraph(telegraphLightUpTime));
            yield return new WaitForSeconds(delayBetweenTelegraphs);
        }
        //pick a new random colour and add it to the list
        PickRandomColour();

    }

    IEnumerator PlayBackSequence()
    {
        yield return new WaitForSeconds(delayBetweenTelegraphs);

        positionInSequence = 0;
        //for every number stored in the list
        foreach(int colourIndex in colourSequence)
        {
            //if timer is 0, stop playing sequence if it's in progress
            if (timer.time <=0)
            {
                yield break;

            }
            //display that stored number's telegraph
            StartCoroutine(telegraphs[colourIndex].DisplayTelegraph(telegraphLightUpTime));
            yield return new WaitForSeconds(delayBetweenTelegraphs);
        }
        //enable buttons again
        EnableButtons();
    }

    void DisableButtons()
    {
        //animation
        animator.SetBool("enabledBool", false);
        
        //disable colliders on buttons to prevent player input
        for (int cnt = 0; cnt < buttons.Length; cnt++)
        {
            buttons[cnt].GetComponent<CircleCollider2D>().enabled = false;
           

        }
    }

    void EnableButtons()
    {
        // play animation
        animator.SetBool("enabledBool", true);
      
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
        StartCoroutine(telegraphs[randomColourIndex].DisplayTelegraph(telegraphLightUpTime));
        
        colourSequence.Add(randomColourIndex);

        //Enable Buttons here
        //I envoke for visual purposes only, so that the collider enables only after telegraph animation is finished
        Invoke("EnableButtons", telegraphLightUpTime);
    }

    public void RestartGame()
    {
        //delete previous colour sequence
        colourSequence.Clear();
        //stop timer 
        timer.startTimerBool = false;
        //call start game function
        //restartButton.SetActive(false);
        startButton.SetActive(true);
        //disable end game menu 
        endGameMenu.SetActive(false);
        //Reset timer
        timer.time = timerTime;
    }

    public void ButtonPressed(int buttonIndex)
    {
       

        if (colourSequence[positionInSequence] == buttonIndex)
        {
           
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
        // disable buttons
        DisableButtons();

        //disable telegraphs
        DisableTelegraphs();
        // - enable menu object
        endGameMenu.SetActive(true);
        
    }

    void DisableTelegraphs()
    {
        for(int cnt = 0; cnt < telegraphs.Length; cnt ++)
        {
            telegraphs[cnt].ResetTelegraph();
        }
    }

    public void LoadNewScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
