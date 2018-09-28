using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour {

    

    private void OnMouseDrag()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 objPos = (Camera.main.ScreenToWorldPoint(mousePos));

        transform.position = objPos;
    }

}
