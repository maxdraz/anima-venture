using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFovLerp : MonoBehaviour {

	Camera camera;
	public float cameraSize;
	public float targetSize;

	public float kingdomSelectSize;
	public float journeySelectSize;

	public bool isLerping;
	bool isReadyForInput;

	// Use this for initialization

	void Start () {
		isLerping = false;
		isReadyForInput = true;
		camera = GetComponent<Camera> ();
		cameraSize = camera.orthographicSize;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (isLerping == true) {
				cameraSize = Mathf.Lerp (cameraSize, targetSize, .02f);
				camera.orthographicSize = cameraSize;
				isReadyForInput = false;

				if (camera.orthographicSize < .91f || camera.orthographicSize > 4f) {
					ReadyForPlayerInput ();
					ToggleTargetSize ();
					ToggleLerpBool ();
					
				}
//			}
			//this one is fine
//			if (cameraSize < journeySelectSize) {
//				cameraSize = Mathf.Lerp (cameraSize, targetSize, .02f);
//				camera.orthographicSize = cameraSize;
//
//				if (camera.orthographicSize > 3.95f) {
//
//					ChangeTargetSizeToJourney ();
//					ToggleLerpBool ();
//				}
//			}
		}
	}



	void ToggleTargetSize () {
		if (targetSize == kingdomSelectSize) {
			targetSize = journeySelectSize;

		} else {
		targetSize = kingdomSelectSize;
		}
	}

	void ReadyForPlayerInput () {

		isReadyForInput = true;
	}

	public void ToggleLerpBool () {
		if (isReadyForInput) {
		if (isLerping == false) {
			
			isLerping = true;

		} else {
		
			isLerping = false;
			}
		}
	}
}


