using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTone : MonoBehaviour {
	public AudioManager audio;
	public int ToneToPlay;
	public float pitch;

	void OnMouseEnter(){

				audio.PlayClip (ToneToPlay, .1f, false, pitch);
			
	}
}
