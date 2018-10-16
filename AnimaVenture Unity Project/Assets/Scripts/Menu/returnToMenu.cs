using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToMenu : MonoBehaviour {

	public Camera main;

    public GameObject node;
    //public GameObject journeySelect;
    public GameObject menu;
    public GameObject background1;
    public GameObject background2;
	public GameObject back;
	public GameObject simon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
    {
        //journeySelect.SetActive(false);
        background1.SetActive(false);
        background2.SetActive(true);
        menu.SetActive(true);
        node.SetActive(true);
		back.SetActive(false);
		simon.SetActive(true);

    }
}
