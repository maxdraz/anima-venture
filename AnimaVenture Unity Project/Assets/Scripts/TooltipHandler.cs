using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour {

    public Text text;
    [SerializeField] List <string> tooltips;
    

	// Use this for initialization
	void Start () {

        int randomIndex = Random.Range(0, tooltips.Count - 1);

        text.text = tooltips[randomIndex];
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
