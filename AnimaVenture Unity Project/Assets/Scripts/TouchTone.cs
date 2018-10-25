using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTone : MonoBehaviour {
	
	public AudioManager audio;
	public int ToneToPlay;
	public float pitch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter(){
	
//		audio.PlayClip (ToneToPlay, .1f, false, pitch);
//		Debug.Log ("Clicked");
	}
}
