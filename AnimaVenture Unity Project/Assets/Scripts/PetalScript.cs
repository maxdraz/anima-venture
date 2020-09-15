using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalScript : MonoBehaviour {

	public AudioManager am;
	Animation anim;
	AudioSource audio;
	SphereCollider collider;
	ParticleSystem particle;
	public float cooldownTime;
	public int toneToPlay;
	public string mixer;

	void Start () {
		collider = GetComponent<SphereCollider> ();
		particle = GetComponentInChildren<ParticleSystem> ();
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}


	public void SwayPetals () {
		anim.Play ();
		am.PlayClip(toneToPlay, mixer);
		particle.Play ();

	}

	public void Activate() {
		collider.enabled = true;
	}

	void Deactivate () {
		collider.enabled = false;
        Debug.Log("broadcasted");
	}

	void OnMouseEnter () {
		Deactivate ();
		Invoke ("Activate", cooldownTime);
		Debug.Log("Mouse Enter");
		SwayPetals ();
	}
}
