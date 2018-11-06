using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour {

    public float speed;
    public Transform startTrans;
    public Transform endTrans;
    public GameObject telegraphToSpawn;


    private void Start()
    {
        transform.position = startTrans.position;
    }

    private void Update()
    {
        MoveObject(speed);
    }

    private void MoveObject(float speed)
    {
        //1
        //transform.position = Vector3.Lerp(transform.position, endTrans.position, Time.deltaTime * speed);

        //2 
        Vector3 current = transform.position;
        Vector3 toTarget = endTrans.position - transform.position;

        transform.position = current + toTarget.normalized * speed * Time.deltaTime;

        if (toTarget.magnitude <= 0.1f)
        {
            transform.position = endTrans.position;
            GameObject telegraphPrefab = (GameObject)Instantiate<GameObject>(telegraphToSpawn);
            telegraphPrefab.transform.position = endTrans.position;
            gameObject.SetActive(false);
        }
    }

    public void setStartPos(Transform start)
    {
        startTrans = start;
        transform.position = startTrans.position;
    }
}
