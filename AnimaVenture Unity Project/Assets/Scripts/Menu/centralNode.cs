using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralNode : MonoBehaviour {
	
	public Camera main;

	//public Camera journeyCamera;
    
	public GameObject node;
    //public GameObject journeySelect;
    public GameObject menu;
	public GameObject background1;
	public GameObject background2;
	public GameObject back;
	public GameObject simon;
    public GameObject botNode;
	public Camera camera;


	private void Start()
	{
		//journeyCamera.SetActive(false);
		//journeySelect.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
        {
            //journeySelect.SetActive(true);
            background1.SetActive(true);
            background2.SetActive(false);
            menu.SetActive(false);
            node.SetActive(false);
			back.SetActive(true);
			simon.SetActive(true);

        }
	}

	private void OnMouseDown()
	{
		//journeySelect.SetActive(true);
//		background1.SetActive(true);
//		background2.SetActive(false);
//		menu.SetActive(false);
//		node.SetActive(false);
//		back.SetActive(true);
//		simon.SetActive(true);
//        botNode.SetActive(true);
		camera.GetComponent<CameraFovLerp> ().ToggleLerpBool ();
	}
}

