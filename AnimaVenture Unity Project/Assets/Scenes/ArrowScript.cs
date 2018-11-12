using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
	Transform mousePos;
	float startYPos;
	bool mouseOver;
    bool lerpBack = false;
	Transform startParent;

	public float lerpBackSpeed;
	public float secondPitchFactor;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	// Use this for initialization
	void Awake () {
		startParent = transform.parent.transform;
		mousePos = GameObject.Find ("MouseTransform").transform;
		mouseOver = false;
		float startYPos = transform.position.y;

		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (lerpBack)
        {
			transform.position = Vector3.Lerp(transform.position, startParent.transform.position, lerpBackSpeed * Time.deltaTime);
        }

		if (transform.position != startParent.transform.position) {

			PitchChange ();
		} else {
		
			lerpBack = false;
		}
    }



	void OnMouseEnter() {
		transform.parent = mousePos;
		mouseOver = true;
        lerpBack = false;
	}

	void OnMouseExit () {
		transform.parent = startParent;
		mouseOver = false;
        lerpBack = true;
	}

	void PitchChange () {
		float firstPitchFactor = startParent.transform.position.y - transform.position.y;
		if (firstPitchFactor < 0f) {
			firstPitchFactor = firstPitchFactor * -1f;

		}
		Debug.Log (firstPitchFactor);
		float finalPitchFactor = firstPitchFactor / secondPitchFactor;
		audio1.pitch = 1 + finalPitchFactor;
		audio2.pitch = 1 + finalPitchFactor;
		audio3.pitch = 1 + finalPitchFactor;

	}
}
