using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPluckScript : MonoBehaviour {

	Animation anim;
	AudioSource audio;
	public BoxCollider2D col1;
	public BoxCollider2D col2;
	public BoxCollider2D col3;

	void Start () {
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void PluckString () {
		anim.Play ();
		audio.Play ();
		Deactivate ();
	}

	public void Activate() {
		col1.enabled = true;
		col2.enabled = true;
		col3.enabled = true;
	}

	void Deactivate () {
		col1.enabled = false;
		col2.enabled = false;
		col3.enabled = false;
	}
}
