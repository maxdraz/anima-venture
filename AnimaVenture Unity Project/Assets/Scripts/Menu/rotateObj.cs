using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {

    public float speed = 0.1f;
    float lerpSpeed = 0.01f;
    Vector3 axis;

	private float angle = 0.0f;

   //public Vector3 force;
   //public Vector3 currentPos;
   //public Vector3 targetPos;
    public float maxSpeed = 1;
    
	void OnMouseDown()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos = Input.mousePosition - pos;
		angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		angle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
	}

	void OnMouseDrag()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;

		float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - angle;
		transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        
        
	}

    void OnMouseUp()
    {
		GetComponent<Rigidbody>().AddForce(Vector3.forward * maxSpeed, ForceMode.VelocityChange);
    }

    void Start()
    {
        axis = Vector3.forward;
    }

    void Update()
    {
        speed = Mathf.Lerp(lerpSpeed, speed, Time.deltaTime);
        transform.Rotate(axis, lerpSpeed * Time.deltaTime * 360);
    }

}
