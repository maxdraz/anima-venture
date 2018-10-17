using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToMenu : MonoBehaviour {

    public bool deactivateThisObj = false;

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
        if (deactivateThisObj)
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
}
