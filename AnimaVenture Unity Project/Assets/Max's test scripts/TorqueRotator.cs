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

        dot = Vector3.Dot(toMouse, mouseDelta);
        axis = setAxisOfRotation(axisOfRotation);

        direction = Input.GetAxis("Horizontal");
        rb.AddTorque(axis * dot *strength * Time.deltaTime);

        
        if (Input.GetMouseButton(0))
        {
            print("dot: " + dot);
        }
     
    }

    private void OnValidate()
    {
       direction = reverseDirection ? -1f : 1f;
        
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
        Debug.DrawLine(mousePos, prevMousePos);
    }
}
