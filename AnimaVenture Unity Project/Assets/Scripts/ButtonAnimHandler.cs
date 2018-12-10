using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimHandler : MonoBehaviour {

	public Animator anim;
	public bool startingButton;

	// Use this for initialization
	void Awake () {
		if (startingButton) {
			FadeIn();
		}
	}
		
	


	public void FadeIn () {
	
		anim.SetBool ("Wait", false);
		anim.SetBool ("FadeIn", true);
		Debug.Log ("FADED IN");
	}

	public void FadeOut () {

		anim.SetBool ("Wait", false);
		anim.SetBool ("FadeIn", false);
		Debug.Log ("FADED OUT");
	}
}
