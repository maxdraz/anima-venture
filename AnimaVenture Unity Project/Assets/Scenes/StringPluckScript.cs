using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPluckScript : MonoBehaviour {

	Animation anim;
	AudioSource audio;
	GameObject colliders;


	void Start () {
		colliders = transform.GetChild (0).transform.gameObject;
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void PluckString () {
		anim.Play ();
		audio.Play ();
		//Deactivate ();
	}

	public void Activate() {
		colliders.SetActive (true);
	}

	void Deactivate () {
		colliders.SetActive (false);
	}
}
