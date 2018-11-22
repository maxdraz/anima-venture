using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {

    TrailRenderer trail;

	// Use this for initialization
	void Start () {
        trail = GetComponent<TrailRenderer>();   
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            trail.enabled = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        if (Input.GetMouseButton(0))
        {
            trail.enabled = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;           
        }

        if (Input.GetMouseButtonUp(0))
        {
            trail.enabled = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }


    }
    
}
