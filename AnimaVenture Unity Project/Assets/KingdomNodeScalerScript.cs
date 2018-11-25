using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomNodeScalerScript : MonoBehaviour {

	Animator animator;

	void Start () {

		animator = GetComponent<Animator> ();
	}

	void OnMouseDown () {
		Debug.Log ("MouseDown");
		animator.SetBool ("ScaleUp", true);
	}

	void OnMouseUp () {
		Debug.Log ("MouseUp");
		animator.SetBool ("ScaleUp", false);
	}
}
