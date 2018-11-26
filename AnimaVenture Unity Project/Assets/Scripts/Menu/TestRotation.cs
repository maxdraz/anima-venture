using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private float angle = 0.1f;

    public float turnSpeed = 10f;
    float lerpSpeed = 0.01f;
    Vector3 axis;
    public float angleZ;
    public bool Rotate;
    public float minThresholdToShowNameText;

    Vector3 angularVel;
    public float z;

    Rigidbody rb;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 startSpin;

    Vector3 currPos;


    float startX;
    float deltaX;

    public float currZ;
    public float lastZ;

    float touchSpeed;

    public Vector3 Torque;
    float timeStart;
    float timeEnd;
	bool firstInput;
	public Animation KingdomLinesFadeIn;
    public GameObject NameText; 
        
        // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startSpin = new Vector3(0, 0, 100 * 12.93f);
        rb.AddTorque(startSpin, ForceMode.Force);
		firstInput = true;
    }

    private void Awake()
    {
        StartCoroutine(Spin());
    }

    private void OnEnable()
    {
        StartCoroutine(Spin());
    }

    // Update is called once per frame
    void Update()
    {
        angularVel = rb.angularVelocity;
        z = angularVel.z * Mathf.Rad2Deg;
        angleZ = transform.eulerAngles.z;
        currZ = angleZ;
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

        if (firstInput)
        {
            NameText.SetActive(true);
            KingdomLinesFadeIn.Play();
            firstInput = false;
        }
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
        timeStart = Time.time;
    }

    void OnMouseUp()
    {
        endPos = Input.mousePosition;
        Vector3 deltaPos = endPos - startPos;
        //Debug.Log("end is " + endPos);

        timeEnd = Time.time;
        touchSpeed = deltaPos.magnitude / (timeEnd - timeStart);
        Debug.Log(touchSpeed);
        if (currZ > lastZ)
        {
            Torque = new Vector3(0, 0, touchSpeed * 1);
            rb.AddTorque(Torque, ForceMode.Force);

            if (touchSpeed > minThresholdToShowNameText)
            {
                //if (firstInput)
               // {
                   // NameText.SetActive(true);
                   // KingdomLinesFadeIn.Play();
                   // firstInput = false;
                //}
            }
        }

        if (currZ < lastZ)
        {
            Torque = new Vector3(0, 0, touchSpeed * -1);
            rb.AddTorque(Torque, ForceMode.Force);
        }
  //      if (touchSpeed < -minThresholdToShowNameText)
    //    {
      //      if (firstInput)
        //    {
          //      NameText.SetActive(true);
            //    KingdomLinesFadeIn.Play();
               // firstInput = false;
            //}
      // }
    }

    IEnumerator Spin()
    {
        float time = .1f;

        while (true)
        {
            if (currZ == lastZ)
            {
                //print("same");
            }
            yield return new WaitForSeconds(time);
            lastZ = currZ;
        }
    }
}
