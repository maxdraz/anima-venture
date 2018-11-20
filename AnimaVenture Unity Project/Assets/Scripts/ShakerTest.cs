using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class ShakerTest : MonoBehaviour {

    public float magnitude, roughness, fadeInTime,fadeOutTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraShaker.Instance.ShakeOnce(magnitude,roughness,fadeInTime, fadeOutTime);
        }
	}
}
