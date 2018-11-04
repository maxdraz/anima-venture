using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringColliderScript : MonoBehaviour {


	void OnMouseEnter () {
		//PluckString ();
		Debug.Log("Plucked");
		transform.parent.GetComponent<StringPluckScript> ().PluckString ();
	}
}
