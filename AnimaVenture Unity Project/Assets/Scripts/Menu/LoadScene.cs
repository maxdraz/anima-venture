using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    int loadingScreenIndex = 4;
    public int sceneIndex;
    public bool loadWithTimerBool = false;
    public float loadAfterTime = 2;

    private void Start()
    {
       if (loadWithTimerBool)
        {
           StartCoroutine(LoadSceneAfterTime());
       }
    }

    public void LoadThisScene()
    {
        SceneToLoad.onlyInstance.SetSceneToLoadNext(sceneIndex);
        SceneManager.LoadScene(loadingScreenIndex, LoadSceneMode.Single);
        
    }

    public void SetSceneIndex(int index)
    {
        sceneIndex = index;
    }

    public IEnumerator LoadSceneAfterTime()
    {
        yield return new WaitForSeconds(loadAfterTime);
        SceneToLoad.onlyInstance.SetSceneToLoadNext(sceneIndex);
        SceneManager.LoadScene(loadingScreenIndex, LoadSceneMode.Single);
   }

    public void StartLoadingSceneAfterTime()
    {
        StartCoroutine(LoadSceneAfterTime());
    }

    private void OnMouseDown()
    {
        LoadThisScene();
    }
}
