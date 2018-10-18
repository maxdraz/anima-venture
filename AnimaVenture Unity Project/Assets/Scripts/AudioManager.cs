using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    [Header("Add all sounds here")]
    public List <AudioClip> audioClips;

    public void PlayClip(int clipIndex) 
    {
        //create a new gobj with an audio source and a destroy script        
        GameObject audioObject = new GameObject(audioClips[clipIndex].name);
        audioObject.transform.parent = transform;
        audioObject.AddComponent<AudioSource>();
        audioObject.AddComponent<Destroy>();

        //populate audio source
        audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];         
        audioObject.GetComponent<AudioSource>().Play();

        //Destroy after done playing
        audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length);
    }

    //Overload 1
    public void PlayClip(int clipIndex, float volume)
    {
        //create a new gobj with an audio source and a destroy script        
        GameObject audioObject = new GameObject(audioClips[clipIndex].name);
        audioObject.transform.parent = transform;
        audioObject.AddComponent<AudioSource>();
        audioObject.AddComponent<Destroy>();

        //populate audio source
        audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
        audioObject.GetComponent<AudioSource>().volume = volume;        
        audioObject.GetComponent<AudioSource>().Play();

        //Destroy after done playing
        audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length);
    }

    //Overload 3
    public void PlayClip(int clipIndex, float volume,  bool loop)
    {
        //create a new gobj with an audio source and a destroy script        
        GameObject audioObject = new GameObject(audioClips[clipIndex].name);
        audioObject.transform.parent = transform;
        audioObject.AddComponent<AudioSource>();
        audioObject.AddComponent<Destroy>();

        //populate audio source
        audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
        audioObject.GetComponent<AudioSource>().loop = loop;
        audioObject.GetComponent<AudioSource>().volume = volume;
        
        audioObject.GetComponent<AudioSource>().Play();
    }
}
