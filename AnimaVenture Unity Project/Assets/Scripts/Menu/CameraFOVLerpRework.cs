using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOVLerpRework : MonoBehaviour {
	


	Camera camera;
	float cameraSize;
	public float targetSize;

	public float kingdomSelectSize;
	public float journeySelectSize;

	public float lerpSpeed;
	bool isLerping;
	bool isReadyForInput;
	public GameObject centralNodeGlow;

	// Use this for initialization

	void Start () {
		camera = GetComponent<Camera> ();
		isLerping = false;
		isReadyForInput = true;
		cameraSize = camera.orthographicSize;
	}

	void FixedUpdate () {

		if (isLerping == true) {

			cameraSize = Mathf.Lerp (cameraSize, targetSize, lerpSpeed);
			camera.orthographicSize = cameraSize;
			isReadyForInput = false;
			//Check for arrival
			/*if (camera.orthographicSize < journeySelectSize + .01f || camera.orthographicSize > kingdomSelectSize - .05f) {
				
				ReadyForPlayerInput ();
				ToggleTargetSize ();
				ToggleLerpBool ();

			}*/
		}
	}

	public void ToggleLerpBool () {

			if (isLerping == false) {

				isLerping = true;
				centralNodeGlow.SetActive (false);

			} else {

				isLerping = false;
			ToggleTargetSize ();
//			centralNodeGlow.GetComponent<centralNode> ().ReadyForInput = true;
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
}