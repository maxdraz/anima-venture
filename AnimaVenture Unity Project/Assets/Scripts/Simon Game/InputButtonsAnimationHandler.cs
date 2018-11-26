using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtonsAnimationHandler : MonoBehaviour {

    public List<Button_Simon> inputButtons;

    public void EnableColliders()
    {
        foreach(Button_Simon button in inputButtons)
        {
            button.EnableCollider();
        }
    }

    public void DisableColliders()
    {
        foreach (Button_Simon button in inputButtons)
        {
            button.DisableCollider();
        }
    }

    public void SetLayers(int layerIndex)
    {
        foreach (Button_Simon button in inputButtons)
        {
            button.gameObject.layer = layerIndex;
        }
    }
}
