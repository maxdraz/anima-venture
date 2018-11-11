using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalScript : MonoBehaviour {

	Animation anim;
	AudioSource audio;
	public SphereCollider collider;
	public ParticleSystem particle;
	public float cooldownTime;

	void Start () {
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void SwayPetals () {
		anim.Play ();
		audio.Play ();
		Deactivate ();
		Invoke ("Activate", cooldownTime);
		particle.Play ();
		Debug.Log("Mouseenter");
	}

	public void Activate() {
		collider.enabled = true;
	}

	void Deactivate () {
		collider.enabled = false;
	}

	void OnMouseEnter () {

		SwayPetals ();
	}
}
