using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {

	private float angle = 0.0f;
    
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

}
