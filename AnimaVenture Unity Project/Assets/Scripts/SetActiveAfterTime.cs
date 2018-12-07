using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAfterTime : MonoBehaviour {

    public List<GameObject> buttons;
    public AnimationClip introAnim;
 

    private void Start()
    {

        StartCoroutine(SetAllActiveAfterTime(introAnim.length));
    }

    IEnumerator SetAllActiveAfterTime(float t) {
        yield return new WaitForSeconds(t);

        

        foreach(GameObject obj in buttons)
        {
            obj.SetActive(true);
        }
        
    }
}
