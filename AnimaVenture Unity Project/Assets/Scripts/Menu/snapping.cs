using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapping : MonoBehaviour {

	private float angle = 0.1f;

	public float turnSpeed = 10f;

	//Quaternion currAng;

	// Update is called once per frame
    void Update()
    {
		//Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		//pos = Input.mousePosition - pos;
		//float currAng = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - angle;

		//Quaternion currAng = transform.rotation;

        //Debug.Log("Angle is " + currAng);

		if (transform.rotation.z > -30 && transform.rotation.z < 30)
        {
            RotateTo(0);
			Debug.Log("Rotating to 0");
        }

        /*if (currAng > 30 && currAng < 90)
        {
            RotateTo(60);
        }

        if (currAng > 90 && currAng < 150)
        {
            RotateTo(120);
        }*/
    }

    void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        transform.rotation = Quaternion.Slerp(transform.rotation, newAng, Time.time * turnSpeed/ 30);
    }
}
