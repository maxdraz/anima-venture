using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    [Header("Add all sounds here")]
    public List <AudioClip> audioClips;
    

    public void PlayClip(int clipIndex) 
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name =audioClips[clipIndex].name;
            

            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().Play();

            //Destroy after done playing
            StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }

    //Overload 1
    public void PlayClip(int clipIndex, float volume)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;


            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().Play();
            audioObject.GetComponent<AudioSource>().volume = volume;

            //Destroy after done playing
            StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
        }
    }

    //Overload 2
    public void PlayClip(int clipIndex, float volume,  bool loop)
    {
        // get an audioObject from pooledObjects list
        GameObject audioObject = ObjectPooler.SharedInstance.GetPooledObject("AudioObject");

        //if an audioObject is available to use
        if (audioObject != null)
        {
            //create a new gobj with an audio source and a destroy script
            audioObject.transform.name = audioClips[clipIndex].name;


            //set the audioObject to active
            audioObject.SetActive(true);

            //populate audio source
            audioObject.GetComponent<AudioSource>().clip = audioClips[clipIndex];
            audioObject.GetComponent<AudioSource>().loop = loop;
            audioObject.GetComponent<AudioSource>().volume = volume;

            audioObject.GetComponent<AudioSource>().Play();

            //Destroy after done playing
            if (!loop)
            {
                StartCoroutine(audioObject.GetComponent<Destroy>().DestroySelf(audioClips[clipIndex].length));
            }
        }       
    }
}
