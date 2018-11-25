using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringColliderScript : MonoBehaviour {


	void OnMouseOver() {
		//PluckString ();
		Debug.Log("Plucked");
		transform.parent.GetComponentInParent<StringPluckScript> ().PluckString ();
	}
}
