using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class simonScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			SceneManager.LoadScene("2_SimonGameBeta", LoadSceneMode.Single);
		}
	}

	private void OnMouseDown()
	{
		SceneManager.LoadScene("2_SimonGameBeta", LoadSceneMode.Single);
	}
}
