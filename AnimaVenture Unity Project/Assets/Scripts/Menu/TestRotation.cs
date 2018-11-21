using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private float angle = 0.1f;

    public float turnSpeed = 10f;
    float lerpSpeed = 0.01f;
    Vector3 axis;
    private float angle1;
    public bool Rotate;

    Vector3 angularVel;
    public float z;

    Rigidbody rb;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 startSpin;

    Vector3 currPos;
    Vector3 lastPos;


    float startX;
    float deltaX;
    float endX;
    float startY;
    float endY;

    float touchSpeed;

    public Vector3 Torque;
    float timeStart;
    float timeEnd;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angle1 = transform.eulerAngles.z;
        startSpin = new Vector3(0, 0, 100 * 12.93f);
        rb.AddTorque(startSpin, ForceMode.Force);
    }

    private void Awake()
    {
        StartCoroutine(Spin());
    }

    // Update is called once per frame
    void Update()
    {
        angularVel = rb.angularVelocity;
        z = angularVel.z * Mathf.Rad2Deg;

        currPos = Input.mousePosition;
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
    }

    void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        transform.rotation = Quaternion.Slerp(transform.rotation, newAng, Time.time * turnSpeed / 30);

    }

    void OnMouseDown()
    {
        rb.angularDrag = 1;
        rb.angularVelocity = new Vector3(0, 0, 0);
        z = 0f;
        Torque = new Vector3(0, 0, 0);
        startPos = Input.mousePosition;
        startX = startPos.x;
        startY = startPos.y;
        timeStart = Time.time;
        //Debug.Log("start is " + startPos);
    }

    void OnMouseUp()
    {
        endPos = Input.mousePosition;
        endX = endPos.x;
        endY = endPos.y;
        Vector3 deltaPos = endPos - startPos;
        //Debug.Log("end is " + endPos);

        timeEnd = Time.time;
        touchSpeed = deltaPos.magnitude / (timeEnd - timeStart);

        //TOP LEFT
        if (endY > Screen.height / 2 && endX < Screen.width / 2 && currPos.y > lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY > Screen.height / 2 && endX < Screen.width / 2 && currPos.y < lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY > Screen.height / 2 && endX < Screen.width / 2 && currPos.y > lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        //TOP RIGHT
        if (endY > Screen.height / 2 && endX > Screen.width / 2 && currPos.y > lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY > Screen.height / 2 && endX > Screen.width / 2 && currPos.y < lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY > Screen.height / 2 && endX > Screen.width / 2 && currPos.y > lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        //BOTTOM RIGHT
        if (endY < Screen.height / 2 && endX > Screen.width / 2 && currPos.y < lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY < Screen.height / 2 && endX > Screen.width / 2 && currPos.y > lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY < Screen.height / 2 && endX > Screen.width / 2 && currPos.y < lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        //BOTTOM LEFT
        if (endY < Screen.height / 2 && endX < Screen.width / 2 && currPos.y > lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY < Screen.height / 2 && endX < Screen.width / 2 && currPos.y < lastPos.y && currPos.x > lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }

        if (endY < Screen.height / 2 && endX < Screen.width / 2 && currPos.y < lastPos.y && currPos.x < lastPos.x)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);
        }
    }

    IEnumerator Spin()
    {
        float time = .1f;

        while (true)
        {
            if (currPos == lastPos)
            {
                //print("same");
            }
            yield return new WaitForSeconds(time);
            lastPos = currPos;
            //print("not same");
        }
    }
}
