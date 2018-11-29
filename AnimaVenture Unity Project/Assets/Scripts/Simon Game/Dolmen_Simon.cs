using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dolmen_Simon : MonoBehaviour {

    public static Dolmen_Simon sharedInstance;

    public float time;
    [SerializeField] float distance;
    [SerializeField] float distanceToTarget;
    [SerializeField] float speed;
    public bool pauseDolmenBool;
    
    public bool moveDolmenBool;
    [SerializeField] GameObject meditationButton;
    [SerializeField] GameObject meditationButtonImage;


    [SerializeField] Transform targetTransform;


    public ParticleSystem ps;

    public GameObject continueSimon;
    public GameObject whiteDolmen;
    public GameObject dolmenGlow;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    { 
        
        distance = CalculateDistance(targetTransform.position.y, transform.position.y);
        speed = distance / time;
    }

    private void FixedUpdate()
    {
        distanceToTarget = CalculateDistance(targetTransform.position.y, transform.position.y);

        
        
        

        if (moveDolmenBool)
        { 
            MoveDolmen();
        }
        
        if(distanceToTarget <= 0)
        {
            StartCoroutine(EnableMeditationButton(4.5f));
            
            moveDolmenBool = false;
            pauseDolmenBool = true;
            continueSimon.GetComponent<ContinueSimon>().enabled = true;

            StopParticleEffect();
        }
       
        
    }

    //calculates the distance between two scalars
    float CalculateDistance(float targetY, float myY)
    {
        float d;
        d = targetY - myY;

        return d;
    }

    public void MoveDolmen()
    {
        // add speed to y value of the transform
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    public IEnumerator SpeedUpDolmen(float spdMultiplier, float t)
    {
        if (!pauseDolmenBool)
        {
            whiteDolmen.SetActive(true);
        }

        float oldSpeed = speed;
        speed *= spdMultiplier;
        yield return new WaitForSeconds(t);
        speed = oldSpeed;
        

    }

    IEnumerator EnableMeditationButton(float t)
    {
        yield return new WaitForSeconds(t);
        meditationButtonImage.SetActive(true);
        meditationButton.SetActive(true);
        dolmenGlow.SetActive(true);


    }

    void StopParticleEffect()
    {
        
        var emission = ps.emission;
        emission.rateOverTimeMultiplier = 0f;

        if(ps.gameObject.transform.childCount > 0)
        {
            
            var childMain = ps.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().main;
            childMain.loop = false;

            var childEmission = ps.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().emission;
            childEmission.rateOverTimeMultiplier = 0f;
        }
    }
}
