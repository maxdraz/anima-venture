using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPluckScript : MonoBehaviour {

	public float cooldownTime;
	Animation anim;
	AudioSource audio;
	GameObject colliders;
	bool canPlay;


	void Start () {
		canPlay = true;
		colliders = transform.GetChild (0).transform.gameObject;
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void PluckString () {
		if (canPlay) {
		anim.Stop ();
		anim.Play ();
		audio.Play ();
		Deactivate ();
		Invoke ("Activate", cooldownTime);
		}
	}

	public void Activate() {
		colliders.SetActive (true);
	}

	void Deactivate () {
		colliders.SetActive (false);
	}
}
