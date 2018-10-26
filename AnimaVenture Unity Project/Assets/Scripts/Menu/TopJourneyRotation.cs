using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopJourneyRotation : MonoBehaviour {

    Rigidbody rb;
    Vector3 axis;
    public float speed = 0.1f;
    public float lerpSpeed = 0.01f;
    public float scale;
    public float maxSize;
    public float growSize;
    public float time;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        axis = Vector3.back;

        StartCoroutine(Scale());
    }

    void Update()
    {
        speed = Mathf.Lerp(lerpSpeed, speed, Time.deltaTime);
        transform.Rotate(axis, lerpSpeed * Time.deltaTime * 360);
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true)
        {
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(.2f, .2f, .2f) * Time.deltaTime * growSize;
                yield return null;
            }

            yield return new WaitForSeconds(time);

            timer = 0;

            while (scale < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(.2f, .2f, .2f) * Time.deltaTime * growSize;
                yield return null;

            }

            timer = 0;
            yield return new WaitForSeconds(time);
        }
    }
}
