using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioManager audioManager;
	AudioSource audio;

	public int toneToPlay;
	public string mixer;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
	{
		audioManager.PlayClip(toneToPlay, mixer);
	}
}
