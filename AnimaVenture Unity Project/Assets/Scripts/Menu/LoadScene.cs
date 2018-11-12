using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

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
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public IEnumerator LoadSceneAfterTime()
    {
        yield return new WaitForSeconds(loadAfterTime);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
