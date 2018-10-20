using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralNode : MonoBehaviour {
	
	public Camera main;

   

	private void OnMouseDown()
	{
		main.GetComponent<CameraFovLerp>(). ToggleLerpBool ();
	}
}

