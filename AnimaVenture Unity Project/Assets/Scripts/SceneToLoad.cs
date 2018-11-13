using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToLoad : MonoBehaviour {


    public static SceneToLoad onlyInstance;
    public int sceneToLoadNext;

    void Start()
    {
        if (onlyInstance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            onlyInstance = this;
        }

        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    public void SetSceneToLoadNext(int index)
    {
        sceneToLoadNext = index;
    }
}
