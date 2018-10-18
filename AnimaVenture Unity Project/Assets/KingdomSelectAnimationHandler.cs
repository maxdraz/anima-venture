using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomSelectAnimationHandler : MonoBehaviour {
	
	public GameObject centralNode;
	//public GameObject journeySelect;
	public GameObject menu;
	public GameObject backButton;
	public GameObject simonStartButton;
	public GameObject orangeNode;
	public Animation journeyAnim;


	public void LeaveKingdom () {
		
		menu.SetActive (false);
		centralNode.GetComponent<CircleCollider2D> ().enabled = false;
		journeyAnim.GetClip ("JourneyFadeIn");
		journeyAnim.Play ();
	}


	public void ArriveAtKingdom () {

		menu.SetActive (true);
		centralNode.GetComponent<CircleCollider2D> ().enabled = true;
	}

	public void LeaveJourney () {
		backButton.SetActive (false);
		simonStartButton.SetActive (false);
		orangeNode.SetActive (false);
		journeyAnim.GetClip ("JourneyFadeOut");
		journeyAnim.Play ();
	}

	public void ArriveAtJourney () {

		backButton.SetActive (true);
		simonStartButton.SetActive (true);
		orangeNode.SetActive (true);

	}
}
