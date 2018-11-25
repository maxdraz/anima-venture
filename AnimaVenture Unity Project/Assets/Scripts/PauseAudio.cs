using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseAudio : MonoBehaviour {

    public AudioSource audio;
    public AudioMixer mixer;
    public float dbPerSecond;
    public bool unpauseBool;

    public void PauseTrack()
    {
        
        StartCoroutine(FadeOutVolume(dbPerSecond, 0, -20));
        
    }

   public IEnumerator FadeOutVolume(float speed, float maxVolume, float targetVolume)
    {
        while (true)
        {           

            maxVolume -= speed * Time.deltaTime;
            Debug.Log(maxVolume);
            mixer.SetFloat("meditationVol", maxVolume);

            if (maxVolume <= targetVolume)
            {
                maxVolume = targetVolume;
                    audio.Pause();
                    yield break;
                
            }

            yield return null;
        }

       
    }

    
    

    }

