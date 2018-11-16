using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleJingleCollider : MonoBehaviour {


	
	void OnTriggerEnter () {
		Debug.Log ("Triggered");
		gameObject.GetComponent<AudioSource> ().Play();
	}
}
