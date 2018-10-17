using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {
    
	private float angle = 0.1f;

	public float turnSpeed = 10f;
	float lerpSpeed = 0.01f;
    Vector3 axis;

	public bool moving;
	private float angle1;


	// Use this for initialization
	void Start()
	{
		angle1 = transform.eulerAngles.z;
	}
	// Update is called once per frame
	void Update()
	{
		if (transform.rotation.z >= -30 || transform.rotation.z <= 30 && !moving)
        {
            RotateTo(0);
            Debug.Log("Rotating to 0");
        }

		/*if (transform.rotation.z >= 30 || transform.rotation.z <= 90 && !moving)
		{
            RotateTo(60);
            Debug.Log("Rotating to 60");
        }*/

		/*if (transform.rotation.z >= 30 && transform.rotation.z <= 90 && !moving)
        {
            RotateTo(60);
            Debug.Log("Rotating to 60");
        }*/
	}

	void OnMouseOver()
    {
        //Object position relative to scrreen
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //Distance gameobject needs to travel to the cursor(finger)
        pos = Input.mousePosition - pos;
        //Calculate angle relative to position of mouse and change to degrees
        angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        angle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
		//Debug.Log("Angle is " + angle);
    }

	void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;

		float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - angle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
		moving = true;
		//Debug.Log("Angle is " + ang);
    }

	void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        transform.rotation = Quaternion.Slerp(transform.rotation, newAng, Time.time * turnSpeed / 30);
    }

	void OnMouseDown()
	{
		
	}

	void OnMouseUp()
	{
		moving = false;
	}
}
