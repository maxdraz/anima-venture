using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegraph_Simon : MonoBehaviour {
    [SerializeField] float lightUpTime = 2f;
    //Sprite renderer reference (only for prototype)
    SpriteRenderer sRenderer;

	// Use this for initialization
	void Start () {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        //(Prototype) set alpha value to half
        ResetTelegraph();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //method for what happens when time to telegraph colour
    public void DisplayTelegraph()
    {
        //this will be changed later to fit our flying stars
        sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            1.0f);

        Invoke("ResetTelegraph", lightUpTime);
    }

    public void ResetTelegraph()
    {
        sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            0.5f);
    }

}
