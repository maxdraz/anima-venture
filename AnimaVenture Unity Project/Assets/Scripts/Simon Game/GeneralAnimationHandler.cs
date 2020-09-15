using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAnimationHandler : MonoBehaviour {

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetBool(string boolName)
    {
        if(anim.GetBool(boolName) == true)
        {
            anim.SetBool(boolName, false);
        }
        else
        anim.SetBool(boolName, true);
    }

}
