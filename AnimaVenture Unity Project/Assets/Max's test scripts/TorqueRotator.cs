using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TorqueRotator : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 axis;
    public enum AxisOfRotation { Forward, Up, Right};
    public AxisOfRotation axisOfRotation;
    public bool reverseDirection;
    private float direction;
    public float strength = 1f;
    private Vector3 mousePos;
    private Vector3 prevMousePos;
    private float dot;
    private float cross;
    bool cursorPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        prevMousePos = mousePos;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Vector3 toMouse = mousePos - transform.position;
        Vector3 mouseDelta = mousePos - prevMousePos;

        if (cursorPressed)
        {
            cross = Vector3.Cross(toMouse, mouseDelta).normalized.z;
            axis = setAxisOfRotation(axisOfRotation);

            direction = Input.GetAxis("Horizontal");
            Vector3 torque = axis * cross * strength * Time.deltaTime;

            rb.AddTorque(torque);
            cursorPressed = false;
        }

        // rotating node towards mouse
        Vector3 toPrevMouse = prevMousePos - transform.position;
        toPrevMouse.Normalize();
        toMouse.Normalize();
        float angleOfRotation = Vector3.Angle(transform.up, toMouse);
        Quaternion targetRotation = Quaternion.AngleAxis(angleOfRotation, transform.forward);
       
        //transform.LookAt()
    }

    private void OnValidate()
    {
       direction = reverseDirection ? -1f : 1f;
        
    }

    Vector3 CalculateTorqueFromMouse()
    {
        prevMousePos = mousePos;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Vector3 toMouse = mousePos - transform.position;
        Vector3 mouseDelta = mousePos - prevMousePos;

        dot = Vector3.Dot(toMouse, mouseDelta);
        cross = Vector3.Cross(toMouse, mouseDelta).normalized.z;
        axis = setAxisOfRotation(axisOfRotation);

        direction = Input.GetAxis("Horizontal");
        Vector3 torque = axis * cross * strength * Time.deltaTime;

        return torque;
    }

    Vector3 setAxisOfRotation(AxisOfRotation axis)
    {
        if(axis == AxisOfRotation.Forward)
        {
            return transform.forward;
        }
        if (axis == AxisOfRotation.Up)
        {
            return transform.up;
        }
        if (axis == AxisOfRotation.Right)
        {
            return transform.right;
        }
        return Vector3.zero;
    }

    private void OnGUI()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        Debug.DrawLine(transform.position, prevMousePos);
        Debug.DrawLine(mousePos, prevMousePos, Color.red);
    }

    private void OnMouseDrag()
    {
       // cursorPressed = true;
    }
}
