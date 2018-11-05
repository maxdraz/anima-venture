using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
	Transform mousePos;
    Vector3 startPos;
	public float botomLimit;

	bool mouseOver;
    bool lerpBack = false;

	// Use this for initialization
	void Awake () {
		mousePos = GameObject.Find ("MouseTransform").transform;
		mouseOver = false;
        startPos = transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (lerpBack)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 1f * Time.deltaTime);
        }
    }



	void OnMouseEnter() {
		transform.parent = mousePos;
		mouseOver = true;
        lerpBack = false;
	}

	void OnMouseExit () {
		transform.parent = null;
		mouseOver = false;
        lerpBack = true;
	}

   
}
