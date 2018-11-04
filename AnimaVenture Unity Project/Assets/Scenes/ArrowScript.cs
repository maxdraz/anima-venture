using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
	float startXPos;
	public float startYPos;
	public float topLimit;
	public float bottomLimit;
	Rigidbody2D rb;
	public bool invertedGravity;
	Vector3 inputPos;
	bool mouseOver;

	// Use this for initialization
	void Awake () {
		mouseOver = false;
		startYPos = transform.position.y;
		startXPos = transform.position.x;

		if (invertedGravity) {
			topLimit = startYPos;
			bottomLimit = topLimit - .7f;

		} else {
		
			bottomLimit = startYPos;
			topLimit = bottomLimit + .7f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseOver) {
			
			inputPos = Input.mousePosition;
			inputPos = Camera.main.ScreenToWorldPoint(inputPos);
			transform.position = new Vector3 (transform.position.x, inputPos.y, 0);
			Debug.Log ("over" + transform.position);

		}

		if (transform.position.y >= topLimit) {

			transform.position = new Vector3 (startXPos, topLimit, transform.position.z);
		}

		if (transform.position.y <= bottomLimit) {

			transform.position = new Vector3 (startXPos, bottomLimit, transform.position.z);
		}
	}



	void OnMouseEnter() {
		mouseOver = true;
	}

	void OnMouseExit () {
		mouseOver = false;
		Debug.Log ("Gone" + transform.position);
	}
}
