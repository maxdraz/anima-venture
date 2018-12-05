using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTriggerHandler : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("HIT");
		if (col.gameObject.tag == "String") {
			Debug.Log ("Call");
			col.gameObject.GetComponent<StringColliderScript> ().CallPluck ();
		}

		if (col.gameObject.tag == "TouchTone") {

			col.gameObject.GetComponent<TouchTone> ().CallTouchTone ();
		}
	}
}
