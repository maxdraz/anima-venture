using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnimation : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Skip();
        }
    }

    void Skip()
    {
        if (animator != null)
        {
            animator.CrossFade("End State", 0f);
        }
    }
}
