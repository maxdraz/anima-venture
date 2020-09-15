using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFadeToAnimation : MonoBehaviour {

	public Animator animator;
    public string stateName;
    public float transitionTime = 0;

    public void CrossFadeToAnim()
    {
        animator.CrossFade(stateName, transitionTime);
    }
}
