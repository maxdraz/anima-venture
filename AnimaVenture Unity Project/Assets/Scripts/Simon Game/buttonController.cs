using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour {

    SpriteRenderer thisRenderer;
    private gameManager GM;

    public int colourNumber;

	void Start () {
        thisRenderer = gameObject.GetComponent<SpriteRenderer>();
        GM = GameObject.FindWithTag("GameManager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        thisRenderer.color = new Color(
            thisRenderer.color.r,
            thisRenderer.color.g,
            thisRenderer.color.b,
            1f);
    }

    private void OnMouseUp()
    {
        thisRenderer.color = new Color(
            thisRenderer.color.r,
            thisRenderer.color.g,
            thisRenderer.color.b,
            0.5f);

        GM.ColourPressed(colourNumber);
    }
}
