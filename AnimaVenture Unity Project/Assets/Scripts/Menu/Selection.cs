using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject menu;
    Collider col;

    public Vector3 oldRotation;
    public Vector3 currRotation;
    public float turnSpeed = 10f;
    public float z;
    public Vector3 angularVel;

    public bool stop = true;

    // Use this for initialization
    void Start()
    {
        oldRotation = menu.transform.rotation.eulerAngles;
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        angularVel = rb.angularVelocity;
        z = angularVel.z * Mathf.Rad2Deg;

        currRotation = menu.transform.rotation.eulerAngles - oldRotation;
        oldRotation = currRotation;

        if (Input.GetKeyDown("space"))
        {
            RotateTo(0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Hit " + other.gameObject.name);

        /*rb.angularDrag = rb.angularDrag + 0.1f;

        if (other.gameObject.name == "Forest" && z < 1f && z > -1f)
        {
            //rb.angularVelocity = Vector3.zero;
            Debug.Log("OI " + z);
            RotateTo(0);
        }*/

    }

    void OnTriggerEnter(Collider other)
    {
        //RotateTo(60);
    }

    void RotateTo(float ang)
    {
        Quaternion newAng = Quaternion.identity;
        newAng.eulerAngles = new Vector3(0, 0, ang);
        menu.transform.rotation = Quaternion.Slerp(menu.transform.rotation, newAng, Time.time * turnSpeed / 300);
    }

}
