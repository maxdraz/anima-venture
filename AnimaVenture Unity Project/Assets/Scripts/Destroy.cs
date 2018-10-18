using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public void DestroySelf(float destroyTime = 0)
    {
        //if destroy time has been specified
        if(destroyTime != 0)
        {
            //destory after time
            Destroy(this.gameObject, destroyTime);
        }
        else
        {
            //if not, destroy staight away
            Destroy(this.gameObject);
        }
    }
}
