using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour {

    public float speed;
    public Transform startTrans;
    public Transform endTrans;
    public GameObject telegraphToSpawn;
    public int telegraphIndex;


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

            Debug.Log("I'm being called");


            transform.position = current + toTarget.normalized * speed * Time.deltaTime;

            if (toTarget.magnitude <= 0.2f)
            {
                transform.position = endTrans.position;
                GameObject telegraphPrefab = ObjectPooler.SharedInstance.GetPooledObject("Telegraph");                
                telegraphPrefab.transform.position = endTrans.position;
                telegraphPrefab.GetComponent<Telegraph>().colourIndex = telegraphIndex;
                telegraphPrefab.SetActive(true);
                gameObject.SetActive(false);

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
}
