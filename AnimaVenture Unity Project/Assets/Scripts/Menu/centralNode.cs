using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralNode : MonoBehaviour {
	
	public Camera main;

    AudioManager AM;

   private void Awake()
    {
        AM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnMouseDown()
	{
        AM.PlayClip(0, 0.1f, false);
        main.GetComponent<CameraFovLerp>(). ToggleLerpBool ();
    }
}

