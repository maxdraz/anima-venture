using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public float startDelayTime;

    public SpriteRenderer[] colours;
    private int colourSelect;
    private float originalAlpha = 0.5f;
    public float stayLitFor;
    private float stayLitTimer;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartDelay(startDelayTime));
	}
	
	// Update is called once per frame
	void Update () {
        
		if(stayLitTimer > 0)
        {
            Debug.Log("Stay lit timer activated " + stayLitTimer);
            stayLitTimer -= Time.deltaTime;


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

    public void RandomStartColour()
    {
        //select random colour
        colourSelect = Random.Range(0, colours.Length);
        Debug.Log(colours[colourSelect].gameObject.name + " selected to be first");
        
        originalAlpha = colours[colourSelect].color.a;
        Debug.Log("Original alpha is " + originalAlpha);
        //raise the alpha of selected colour (glow effect)
        colours[colourSelect].color = new Color(
            colours[colourSelect].color.r,
            colours[colourSelect].color.g,
            colours[colourSelect].color.b, 
            1f);

        stayLitTimer = stayLitFor;
    }

   
    
    IEnumerator StartDelay(float t)
    {
        // wait for t seconds
        yield return new WaitForSeconds(t);
        //call random select function
        Debug.Log("Game started");
        RandomStartColour();
    }
}
