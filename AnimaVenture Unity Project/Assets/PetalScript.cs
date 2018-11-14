using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalScript : MonoBehaviour {

	Animation anim;
	AudioSource audio;
	SphereCollider collider;
	ParticleSystem particle;
	public float cooldownTime;

	void Start () {
		collider = GetComponent<SphereCollider> ();
		particle = GetComponentInChildren<ParticleSystem> ();
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void SwayPetals () {
		anim.Play ();
		audio.Play ();
		particle.Play ();

	}

	public void Activate() {
		collider.enabled = true;
	}

	void Deactivate () {
		collider.enabled = false;
	}

	void OnMouseEnter () {
		Deactivate ();
		Invoke ("Activate", cooldownTime);
		Debug.Log("Mouse Enter");
		SwayPetals ();
	}
}
