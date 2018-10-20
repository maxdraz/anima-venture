using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour {

    [SerializeField] int resWidth, resHeight;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(resWidth, resHeight, false);
	}
	
	
}
