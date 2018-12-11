using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayFadeOut : MonoBehaviour {

    public GameObject fadeOutScreen;
    public float delay;
	
	public void FadeOutMethod()
    {
        StartCoroutine(FadeOut(delay));
    }

    IEnumerator FadeOut(float t)
    {
        yield return new WaitForSeconds(t);

        fadeOutScreen.SetActive(true);
    }
}
