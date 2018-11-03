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

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		startYPos = transform.position.y;
		startXPos = transform.position.x;

		if (invertedGravity) {
			topLimit = startYPos;

		} else {
		
			bottomLimit = startYPos;
		}
	}
	
	// Update is called once per frame
	void Update () {
		inputPos = Input.mousePosition;
		inputPos.z = 10;
		inputPos = Camera.main.ScreenToWorldPoint(inputPos);

		if (transform.position.y >= topLimit) {

			transform.position = new Vector3 (startXPos, topLimit, 0);
		}

		if (transform.position.y <= bottomLimit) {

			transform.position = new Vector3 (startXPos, bottomLimit, 0);
		}
	}

	void OnMouseOver() {

		transform.position = inputPos;
		Debug.Log ("dragging");
	}

	void OnMouseExit () {

		Debug.Log ("Gone");
	}
}
