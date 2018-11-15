using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionScript : MonoBehaviour {
	
	Vector3 inputPos;


	// Update is called once per frame
	void Update () {
					inputPos = Input.mousePosition;
					inputPos = Camera.main.ScreenToWorldPoint(inputPos);
					transform.position = new Vector3 (transform.position.x, inputPos.y, 0);
	}
}
