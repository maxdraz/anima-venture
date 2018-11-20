using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralNode : MonoBehaviour {
	public Camera main;
	public Animator KingdomFadeAnim;

    AudioManager AM;
	public bool ReadyForInput;

   private void Awake()
    {
		ReadyForInput = true;
        AM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

	    private void OnMouseDown()
		{
			if (ReadyForInput) {
				ReadyForInput = false;
			//        main.GetComponent<CameraFovLerp>(). ToggleLerpBool ();
	        AM.PlayClip(0, 0.1f, false);

			StartAnimation ();
		}
	}

	public void StartAnimation () {
//		Debug.Log ("START FADE ANIM");
		KingdomFadeAnim.SetBool ("Wait", false);
		if (main.GetComponent<CameraFOVLerpRework> ().targetSize == .9f) {
			KingdomFadeAnim.SetBool ("FadeToKingdom", false);
//			Debug.Log ("FADE TO J SELECT");


		}

		if (main.GetComponent<CameraFOVLerpRework> ().targetSize == 4.85f){

			KingdomFadeAnim.SetBool ("FadeToKingdom", true);
			ReadyForInput = true;
//			Debug.Log ("FADE TO K  SELECT");

		}
	}

}
