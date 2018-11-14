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

	void OnMouseEnter(){

				audio.PlayClip (ToneToPlay, .3f, false, pitch);
				particle.Play ();
			
	}
}
