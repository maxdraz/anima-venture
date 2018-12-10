using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class EventHandler : MonoBehaviour {

	public static EventHandler SharedInstance;
    public bool testingMode;
    [Space(15)]
    public TimelineAsset introTimeline;
    public AnimationClip tip1Anim;

    public UnityEngine.Events.UnityEvent playIntroCutscene;
    public UnityEngine.Events.UnityEvent tip1Trigger;
    public UnityEngine.Events.UnityEvent startSimon;
    public UnityEngine.Events.UnityEvent tip2Trigger;
    public UnityEngine.Events.UnityEvent groundExplosionTrigger;
    public UnityEngine.Events.UnityEvent startDolmenPS;
    public UnityEngine.Events.UnityEvent startRainPS;
    public UnityEngine.Events.UnityEvent startBottomPS;
    public UnityEngine.Events.UnityEvent tip3Trigger;


    private void Awake()
    {
        SharedInstance = this;
        
    }

    private void Start()
    {
        //play backing track
        AudioManager.SharedInstance.PlayClip(5, "Simon Music", true);

        if (testingMode)
        {
            StartCoroutine(StartSimon(0.5f));
        }
        else
        {
            StartCoroutine(DisplayTip1(2f));
        }
        // COMMENTED FOR TESTING
       // playIntroCutscene.Invoke();

        // StartCoroutine(StartSimon(1));      
        //StartCoroutine(DisplayTip1(2f));

        // COMMENTED FOR TESTING
         //StartCoroutine(DisplayTip1((float)introTimeline.duration));
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

    public IEnumerator StartDolmen()
    {
      
        groundExplosionTrigger.Invoke();
        yield return new WaitForSeconds(0.5f);
        startDolmenPS.Invoke();
        Dolmen_Simon.sharedInstance.moveDolmenBool = true;
       
    }

    

}
