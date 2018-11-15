using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour {

    public float speed;
    public float setInactiveAfter;
    public Transform startTrans;
    public Transform endTrans;
    public GameObject telegraphToSpawn;
    public int telegraphIndex;
    public ParticleSystem trailPS;
    public ParticleSystem headPS;
    
    public float endStartSize;
     float originalTrailStartSize;
    float originalHeadStartSize;



    private void OnEnable()
    {
       // MoveObject(speed);
    }

    private void Start()
    {
        
    }
    

    public IEnumerator MoveObject(float speed)
    {
        //1
        //transform.position = Vector3.Lerp(transform.position, endTrans.position, Time.deltaTime * speed);

        //2 
        while (true)
        {
            Vector3 current = transform.position;
            Vector3 toTarget = endTrans.position - transform.position;
            transform.position = current + toTarget.normalized * speed * Time.deltaTime;

            if (toTarget.magnitude <= 0.1f)
            {
                transform.position = endTrans.position;
                GameObject telegraphPrefab = ObjectPooler.SharedInstance.GetPooledObject("Telegraph");                
                telegraphPrefab.transform.position = endTrans.position;
                telegraphPrefab.GetComponent<Telegraph>().colourIndex = telegraphIndex;
                telegraphPrefab.SetActive(true);

                //make colour of particles fade out 
                var trailMain = trailPS.main;
                var headSizeOverLife = headPS.sizeOverLifetime;

                originalTrailStartSize = trailMain.startSize.constant;
               // originalHeadStartSize = headMain.startSize.constant;

                trailMain.startSize = endStartSize;
                headSizeOverLife.enabled = true;
                headSizeOverLife.sizeMultiplier = 0.01f;
               // headEmmision.enabled = false;

                StartCoroutine(SetInactiveAfterTime(setInactiveAfter));

                yield break;
                
            }

            yield return null;

        }


        } 
    

    public void setStartPos(Transform start)
    {
        startTrans = start;
        transform.position = startTrans.position;
    }

    IEnumerator SetInactiveAfterTime(float t)
    {
        yield return new WaitForSeconds(t);

        var trailMain = trailPS.main;
        //  var headMain = headPS.main;
        var headSizeOverLife = headPS.sizeOverLifetime;
        headSizeOverLife.enabled = false;

        trailMain.startSize = originalTrailStartSize;
      //  headMain.startSize = originalHeadStartSize;

        gameObject.SetActive(false);
      
    }
}
