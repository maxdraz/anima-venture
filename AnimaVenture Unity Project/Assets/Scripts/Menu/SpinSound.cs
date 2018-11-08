using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSound : MonoBehaviour {

    AudioManager AM;
    Rigidbody rb;

    Vector3 angVel;
    public float z;

    public AudioClip spinSound;
    public AudioSource spin;
    public float volume;

	// Use this for initialization
	void Start ()
    {

        volume = 0f;
        spin.clip = spinSound;
        spin.Play();
    }


    private void Awake()
    {
        AM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    /*private void OnMouseUp()
    {
        AM.PlayClip(2, volume, false);
    }*/

    // Update is called once per frame
    void Update ()
    {
        angVel = rb.angularVelocity;
        z = angVel.z;

        spin.volume = z;

        if (z < 0)
        {
            z = -z;
            spin.volume = z;
        }
    }
}
