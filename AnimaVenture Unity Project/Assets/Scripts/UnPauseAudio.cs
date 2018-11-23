using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPauseAudio : MonoBehaviour {

    public AudioSource audio;

    public void UnPauseTrack()
    {
        audio.UnPause();
    }
}
