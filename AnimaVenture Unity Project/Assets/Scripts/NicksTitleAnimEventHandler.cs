using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicksTitleAnimEventHandler : MonoBehaviour {

	public GameObject[] letters;


	public void ActivateLetters (int letterToActivate) {

		letters [letterToActivate].SetActive (true);
	}
}
