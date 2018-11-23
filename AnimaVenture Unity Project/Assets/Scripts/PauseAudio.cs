using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseAudio : MonoBehaviour {

    public AudioSource audio;
    public AudioMixer mixer;

    public void PauseTrack()
    {
        
        StartCoroutine(FadeOutVolume(80f, 0));
        
    }

   public IEnumerator FadeOutVolume(float speed, float maxVolume)
    {
        while (true)
        {           

            maxVolume -= speed * Time.deltaTime;
            Debug.Log(maxVolume);
            mixer.SetFloat("meditationVol", maxVolume);

            if (maxVolume <= -80)
            {
                audio.Pause();
                this.gameObject.SetActive(false);
                yield break;
            }

            yield return null;
        }

       
    }
    

    }

