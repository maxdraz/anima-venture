using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnStart : MonoBehaviour {

    public bool PlayOnStart;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (PlayOnStart) {
            anim.SetBool("Wait", false);
        }
	}
}
