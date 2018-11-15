using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedLoad : MonoBehaviour {

    public bool ready = false;

    public GameObject menu;

    public Camera camera;

    //Kingdom assets
    public SpriteRenderer kBackground;
    public GameObject centralNode;
    public GameObject kingdomMenu;
    //	public GameObject kingdomLines;
    public GameObject kingdomArrows;
    public GameObject kingdomDots;
    public GameObject centralNodeGlow;
    public GameObject returnMenu;


    //Journey Assets
    public SpriteRenderer jBackground;
    public GameObject backButton;
    public GameObject journeyLines;
    public GameObject journeyDots;
    public GameObject journey1;
    public GameObject journey2;
    public GameObject kingdomButton;
    public GameObject settingsButton;

    void Start ()
    {
   
    }
	

	void Update ()
    {
		if(ready)
        {
            camera.orthographicSize = 0.9f;
            //Journey to Active
            Color c = jBackground.material.color;
            c.a = 1;
            backButton.SetActive(true);
            journeyLines.SetActive(true);
            journeyDots.SetActive(true);
            journey1.SetActive(true);
            journey2.SetActive(true);
            kingdomButton.SetActive(true);
           // settingsButton.SetActive(true);

            //Kingdom to Inactive
            Color b = kBackground.material.color;
            c.a = 0;
            kingdomMenu.SetActive(false);
            kingdomDots.SetActive(false);
            kingdomArrows.SetActive(false);
            returnMenu.SetActive(false);
            //kingdomLines.SetActive (false);
            centralNode.GetComponent<CircleCollider2D>().enabled = false;
        }

        if(camera.orthographicSize == 0.9f)
        {
            ready = false;
        }
	}
}
