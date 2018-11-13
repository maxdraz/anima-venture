using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class EventHandler : MonoBehaviour {

	public static EventHandler SharedInstance;
    public TimelineAsset introTimeline;
    public AnimationClip tip1Anim;

    public UnityEngine.Events.UnityEvent playIntroCutscene;
    public UnityEngine.Events.UnityEvent tip1Trigger;
    public UnityEngine.Events.UnityEvent startSimon;
    public UnityEngine.Events.UnityEvent tip2Trigger;

    
    private void Awake()
    {
        SharedInstance = this;
        
    }

    private void Start()
    {
        playIntroCutscene.Invoke();
        StartCoroutine(DisplayTip1((float)introTimeline.duration));
    }

    private void Update()
    {
        
    }

    IEnumerator DisplayTip1(float t)
    {
        yield return new WaitForSeconds(t);
        tip1Trigger.Invoke();

        StartCoroutine(StartSimon(tip1Anim.length));

    }

    IEnumerator StartSimon(float t)
    {
        yield return new WaitForSeconds(t);
        startSimon.Invoke();
    }

    

}
