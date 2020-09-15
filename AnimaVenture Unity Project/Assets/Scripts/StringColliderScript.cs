using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringColliderScript : MonoBehaviour {


	void OnTriggerEnter2d(Collider2D col) {
		//PluckString ();
		Debug.Log("Plucked");
		transform.parent.GetComponentInParent<StringPluckScript> ().PluckString ();
	}

	public void CallPluck () {

		transform.parent.GetComponentInParent<StringPluckScript> ().PluckString ();
	}
}
