using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOrInactive : MonoBehaviour {

    public bool deactivateThisObjToo = false;
    public bool onEnable = false;
    public bool onMouseDown = false;

    [Space(5)]
    [Header("Lists of Game Objects to set Active/ Inactive")]
    [Space(5)]
    public List<GameObject> toSetActive;
    public List<GameObject> toSetInactive;

	public void Execute()
    { 
        SetAllActive();
        SetAllInactive();

        //set this object to Inactive
        if (deactivateThisObjToo)
        {
            gameObject.SetActive(false);
        }
        else
            return;

    }

    void SetAllActive()
    {
        if (toSetActive != null)
        {
            foreach (GameObject objectRef in toSetActive)
            {
                if (objectRef != null)
                {
                   objectRef.SetActive(true);
                }
                else break;
            }
        }
        else
            return;
    }

    void SetAllInactive()
    {
        if (toSetActive != null)
        {
            foreach (GameObject objectRef in toSetInactive)
            {
                if (objectRef != null)
                {
                    objectRef.SetActive(false);
                }
                else break;
            }
        }
        else
            return;
    }

    private void OnMouseDown()
    {
        if(onMouseDown)
        Execute();
    }

    private void OnEnable()
    {
        if (onEnable)
            SetAllActive();
    }

    private void OnDisable()
    {
        if (onEnable)
            SetAllInactive();
    }
}
