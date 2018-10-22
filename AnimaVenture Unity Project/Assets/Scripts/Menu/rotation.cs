using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

    private float angle = 0.1f;

    public float turnSpeed = 10f;
    float lerpSpeed = 0.01f;
    Vector3 axis;
    private float angle1;
    public bool Rotate;

    Rigidbody rb;
    Vector3 startPos;
    Vector3 endPos;
    float startX;
    float deltaX;
    float endX;
    float startY;
    float endY;

    float touchSpeed;

    Vector3 Torque;
    float timeStart;
    float timeEnd;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angle1 = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {

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
        RotateObj();
    }

    void RotateObj()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;

        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - angle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        //      Debug.Log("Angle is " + ang);
    }

    void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        transform.rotation = Quaternion.Slerp(transform.rotation, newAng, Time.time * turnSpeed / 30);

    }

    void OnMouseDown()
    {
        startPos = Input.mousePosition;
        startX = startPos.x;
        startY = startPos.y;
        timeStart = Time.time;
        Debug.Log("start is " + startPos);

    }

    void OnMouseUp()
    {
        endPos = Input.mousePosition;
        endX = endPos.x;
        endY = endPos.y;
        Vector3 deltaPos = endPos - startPos;
        Debug.Log("end is " + endPos);

        timeEnd = Time.time;
        touchSpeed = deltaPos.magnitude / (timeEnd - timeStart);

        //Torque = new Vector3(0, 0, touchSpeed * 1);
        //rb.AddTorque(Torque, ForceMode.Force);

        if (startY < Screen.height / 2 && endX < startX)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        else if (startY > Screen.height / 2 && endX > startX)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        else if (startY < Screen.height / 2 && endX > startX)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        else if (startY > Screen.height / 2 && endX < startX)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        else if (startX < Screen.width / 2 && endX > Screen.width)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }
    }
}
