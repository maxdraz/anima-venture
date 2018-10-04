using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public float startDelayTime;

    public SpriteRenderer[] colours;
    private int colourSelect;
    private float originalAlpha = 0.5f;
    public float stayLitFor;
    public float delayBetweenLights;
    private float delayBetweenLightsTimer;
    private float stayLitTimer;
    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> colourSequence;
    private int positionInSequence;

    

	// Use this for initialization
	void Start () {
        StartCoroutine(StartDelay(startDelayTime));
	}
	
	// Update is called once per frame
	void Update () {
        //code for when the telegraph displays the sequence
		if(shouldBeLit) // when the telegraph is told it should light up...
        {
            //.. start counting down the time it should be lit for.
            stayLitTimer -= Time.deltaTime;

            //when the timer reaches 0..
            if(stayLitTimer < 0)
            {

                // ...dim the alpha / display faded animation
                colours[colourSequence[positionInSequence]].color = new Color(
           colours[colourSequence[positionInSequence]].color.r,
           colours[colourSequence[positionInSequence]].color.g,
           colours[colourSequence[positionInSequence]].color.b,
           0.5f);

                //tell the telegraph it shouldn't be lit anymore
                shouldBeLit = false;
                //set the bool and timer for the delay between telegraphs
                shouldBeDark = true;
                delayBetweenLightsTimer = delayBetweenLights;
                //add 1 to the position in sequence
                positionInSequence++;
            }

            //code for the delay between telegraphs 
            if (shouldBeDark)
            {
                delayBetweenLightsTimer -= Time.deltaTime;

                //if(positionInSequence >= colourSequence)
            }


        } else
        {
            //return alpha to original colour
            colours[colourSelect].color = new Color(
                colours[colourSelect].color.r,
                colours[colourSelect].color.g,
                colours[colourSelect].color.b,
                originalAlpha);

            Debug.Log("Alpha reset to original");
        }
	}

    // function which chooses a random telegraph colour
    public void RandomStartColour()
    {

        positionInSequence = 0;
        //select random colour
        colourSelect = Random.Range(0, colours.Length);
        //add this random colour to the first position in sequence
        colourSequence.Add(colourSelect);     
        
        //raise the alpha of selected colour (glow effect) / play animation in future
        colours[colourSequence[positionInSequence]].color = new Color(
            colours[colourSequence[positionInSequence]].color.r,
            colours[colourSequence[positionInSequence]].color.g,
            colours[colourSequence[positionInSequence]].color.b, 
            1f);

        Debug.Log(positionInSequence);
        stayLitTimer = stayLitFor;
        shouldBeLit = true;
    }

   
    //coroutine which delays the start of the minigame
    IEnumerator StartDelay(float t)
    {
        // wait for t seconds
        yield return new WaitForSeconds(t);
        //call random select function
        Debug.Log("Game started");
        RandomStartColour();
    }

    //function for when a colour button is pressed
    public void ColourPressed(int whichButton)
    {
        if(colourSelect == whichButton)
        {
            //if correct button do this:
            Debug.Log("Correct button pressed");

        } else if(colourSelect != whichButton)
        {
            //if wrong button do this:
            Debug.Log("Wrong button pressed");
        }
    }
}
