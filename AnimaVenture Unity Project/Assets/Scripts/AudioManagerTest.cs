using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour {

    AudioManager AM;

    private void Awake()
    {
        AM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AM.PlayClip(0,1);
        }
    }
}
