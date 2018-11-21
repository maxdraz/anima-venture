using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomNodeScalerScript : MonoBehaviour {

	Animator animator;

	void Start () {

		animator = GetComponent<Animator> ();
	}

	void OnMouseEnter () {
		Debug.Log ("MouseDown");
		animator.SetBool ("ScaleUp", true);
	}

	void OnMouseExit () {
		Debug.Log ("MouseUp");
		animator.SetBool ("ScaleUp", false);
	}
}
