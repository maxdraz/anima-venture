using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour
{
    //Roatations
    Rigidbody rb;
    public float speed = 0.1f;
    public float turnSpeed = 10f;
    float lerpSpeed = 0.01f;
    Vector3 axis;

    private float angle = 0.0f;

    Vector2 startPos;
    Vector2 endPos;
    float touchSpeed;
    Vector3 Torque;
    float timeStart;
    float timeEnd;

    void OnMouseOver()
    {
        //Object position relative to scrreen
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //Distance gameobject needs to travel to the cursor(finger)
        pos = Input.mousePosition - pos;
        //Calculate angle relative to position of mouse and change to degrees
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

    private void OnMouseDown()
    {
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        timeStart = Time.time;
    }

    private void OnMouseUp()
    {
        timeEnd = Time.time;
        endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 deltaPos = endPos - startPos;
        touchSpeed = deltaPos.magnitude / (timeEnd - timeStart);

        Torque = new Vector3(0, 0, touchSpeed * 1);
        rb.AddTorque(Torque, ForceMode.Impulse);

        Debug.Log("X component is " + deltaPos.x);
        Debug.Log("Y component is " + deltaPos.y);

        /*if(deltaPos.x > 0)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Impulse);
        }*/
    }

    void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        transform.rotation = Quaternion.Slerp(transform.rotation, newAng, Time.time * turnSpeed / 30);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //axis = Vector3.forward;
    }

    void Update()
    {
        //speed = Mathf.Lerp(lerpSpeed, speed, Time.deltaTime);
        //transform.Rotate(axis, lerpSpeed * Time.deltaTime * 360);

        //RotateTo(0);
    }

}
