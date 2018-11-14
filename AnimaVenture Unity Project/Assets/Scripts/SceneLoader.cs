using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public int sceneToLoad;
    public float timeDelay;

    private void Start()
    {
        sceneToLoad = SceneToLoad.onlyInstance.sceneToLoadNext;
        StartCoroutine(LoadSceneAsyncWithDelay(sceneToLoad, timeDelay));
    }

    public IEnumerator LoadSceneAsyncWithDelay(int sceneIndex, float timeDelay)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

       operation.allowSceneActivation = false;

        

        yield return new WaitForSeconds(timeDelay);

        operation.allowSceneActivation = true;



    }
}
