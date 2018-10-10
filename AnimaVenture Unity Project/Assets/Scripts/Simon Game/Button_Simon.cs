using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Simon : MonoBehaviour {

    GameManager_Simon gm;
    Animator animator;

    //assign the same index as in the array on gm
    public int ButtonIndex { get; set; }

    private void Awake()
    {
        //References to objects / components
        animator = gameObject.GetComponent<Animator>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager_Simon>();
    }

    private void OnMouseDown()
    {
        //animate
        animator.SetBool("tapBool", true);

        //tell the GM which button was pressed
        gm.ButtonPressed(ButtonIndex);
    }

    private void OnMouseUp()
    {
        //animate
        animator.SetBool("tapBool", false);
    }
}
