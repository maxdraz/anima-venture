using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {

    public float speed;
    public Transform startTrans;
    public Transform endTrans;
    bool boolo = true;
    

    private void Start()
    {
        transform.position = startTrans.position;
    }

    private void Update()
    {

        if (boolo)
        {
            MoveObject(speed);
        }
        
        
    }

    private void MoveObject(float speed)
    {
        //1
        //transform.position = Vector3.Lerp(transform.position, endTrans.position, Time.deltaTime * speed);

        //2 
        Vector3 current = transform.position;
        Vector3 toTarget = endTrans.position - transform.position;

        transform.position = current + toTarget.normalized * speed * Time.deltaTime;

        if(toTarget.magnitude <= 0.1f)
        {
            boolo = false;
        }
    }
}
