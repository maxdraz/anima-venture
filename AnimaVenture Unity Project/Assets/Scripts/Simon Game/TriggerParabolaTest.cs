using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParabolaTest : MonoBehaviour {
    public List<ParabolaController> trajectories;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerParabola(3);
        }
	}

   void TriggerParabola(int colourIndex)
    {
        for(int i = 0; i < trajectories.Count; i++)
        {
            trajectories[colourIndex].FollowParabola();
           
        }
        
    }

   
}
