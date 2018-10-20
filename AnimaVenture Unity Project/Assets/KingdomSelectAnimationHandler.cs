using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomSelectAnimationHandler : MonoBehaviour {
	
	public GameObject centralNode;
	public GameObject kingdomMenu;
	public GameObject kingdomLines;
	public GameObject kingdomDots;
	public GameObject backButton;
	public GameObject simonStartButton;
	public GameObject journeyLines;
	public GameObject journey1;
	public GameObject journey2;
	public Animation journeyAnim;


	public void LeaveKingdom () {
		Debug.Log ("Leave kingdom");
		kingdomMenu.SetActive (false);
		kingdomDots.SetActive (false);
		kingdomLines.SetActive (false);
		centralNode.GetComponent<CircleCollider2D> ().enabled = false;
		journeyAnim.clip = journeyAnim.GetClip ("JourneyFadeIn");	
		journeyAnim.Play ();
	}


	public void ArriveAtKingdom () {
		Debug.Log ("arrive at kingdom");

		kingdomMenu.SetActive (true);
		kingdomDots.SetActive (true);
		kingdomLines.SetActive (true);
		centralNode.GetComponent<CircleCollider2D> ().enabled = true;
	}

	public void LeaveJourney () {
		Debug.Log ("Leave journey");

		backButton.SetActive (false);
		simonStartButton.SetActive (false);
		journey1.SetActive (false);
		journey2.SetActive (false);
		journeyLines.SetActive (false);
		journeyAnim.clip = journeyAnim.GetClip ("JourneyFadeOut");
		journeyAnim.Play ();
	}

	public void ArriveAtJourney () {
		Debug.Log ("arrive at journey");

		backButton.SetActive (true);
		simonStartButton.SetActive (true);
		journeyLines.SetActive (true);
		journey1.SetActive (true);
		journey2.SetActive (true);

	}
}
