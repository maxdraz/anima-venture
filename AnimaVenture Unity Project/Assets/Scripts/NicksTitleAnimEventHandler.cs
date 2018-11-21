using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicksTitleAnimEventHandler : MonoBehaviour {

	public ParticleSystem[] particles;


	public void ActivateParticles () {
		for (int i = 0; i < particles.Length; i++){

			particles [i].Play ();
		}
	}
}
