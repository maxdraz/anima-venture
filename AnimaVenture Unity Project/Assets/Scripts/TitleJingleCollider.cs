using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleJingleCollider : MonoBehaviour {
	
	Text letter;
	ParticleSystem particle;




	public void PlayParticle() {
		particle = GetComponent<ParticleSystem> ();
		particle.Play ();
	}

	public void ActivateLetter() {
		letter = GetComponent<Text> ();
		letter.enabled = true;
	}

	void OnTriggerEnter () {
		Debug.Log ("Triggered");
		gameObject.GetComponent<AudioSource> ().Play();
	}
}
