using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueSimon : MonoBehaviour {

    GameManager_Simon gm;
    EventHandler eh;
    Animator animator;
    public bool dolmenCompleteBool = false;

    private void Awake()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager_Simon>();
        eh = GameObject.FindWithTag("GameManager").GetComponent<EventHandler>();
        animator = gameObject.GetComponentInParent<Animator>();
    }

    private void OnEnable()
    {
        dolmenCompleteBool = true;
    }

    private void Update()
    {
        
        if (dolmenCompleteBool)
        {
            eh.tip3Trigger.Invoke();
            StartCoroutine(SetColliderActive(1f));
            
        }
    }

    private void OnMouseDown()
    {
       StartCoroutine(ContinuePlayingSimon());

    }

    IEnumerator ContinuePlayingSimon()
    {
        animator.SetBool("continueBool", true);
        StartCoroutine(gm.PlayGame());
        
        dolmenCompleteBool = false;
        yield return new WaitForSeconds(1f);
        animator.SetBool("continueBool", false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        
    }

    IEnumerator SetColliderActive(float t)
    {
        yield return new WaitForSeconds(t);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
