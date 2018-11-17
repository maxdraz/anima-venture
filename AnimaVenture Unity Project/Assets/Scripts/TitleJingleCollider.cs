using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleJingleCollider : MonoBehaviour {

	ParticleSystem particle;


	public void PlayParticle() {
		particle = GetComponent<ParticleSystem> ();
		particle.Play ();
	}


	void OnTriggerEnter () {
		Debug.Log ("Triggered");
		gameObject.GetComponent<AudioSource> ().Play();
	}
}
