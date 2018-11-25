using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UnPauseAudio : MonoBehaviour {

    public AudioSource audio;
    public AudioMixer mixer;
    public float dbPerSecond;
    

    public void UnPauseTrack()
    {

        StartCoroutine(FadeInVolume(dbPerSecond, -20f, 0));
       
    }

    

    public IEnumerator FadeInVolume(float speed, float lowestVolume, float targetVolume)
    {
        while (true)
        {
            audio.UnPause();

            lowestVolume += speed * Time.deltaTime;
            
            mixer.SetFloat("meditationVol", lowestVolume);

            if (lowestVolume >= targetVolume)
            {
                mixer.SetFloat("meditationVol", targetVolume);

                yield break;
            }

            yield return null;
        }


    }
}
