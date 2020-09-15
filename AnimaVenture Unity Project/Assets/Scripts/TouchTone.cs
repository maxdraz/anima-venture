using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTone : MonoBehaviour {
	public AudioManager audio;
	public int ToneToPlay;
	public float pitch;
	ParticleSystem particle;

	void Start () {

		particle = GetComponentInChildren<ParticleSystem> ();

	}

//	void OnTriggerEnter2D(Collider2D col){
//
//				audio.PlayClip (ToneToPlay, "Harp");
//				particle.Play ();
//	}

	public void CallTouchTone () {
	
		audio.PlayClip (ToneToPlay, "Harp");
		particle.Play ();
	}
}
