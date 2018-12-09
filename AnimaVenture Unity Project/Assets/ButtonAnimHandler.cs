using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimHandler : MonoBehaviour {

	Animation anim;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animation> ();	
		FadeIn();
	}
		
	


	public void FadeIn () {
	
		anim.clip = anim.GetClip ("Ui Button FadeIn");
		anim.Play ();
		Debug.Log ("FADED IN");
	}

	public void FadeOut () {

		anim.clip = anim.GetClip ("Ui Button FadeOut");
		anim.Play ();
		Debug.Log ("FADED OUT");
	}
}
