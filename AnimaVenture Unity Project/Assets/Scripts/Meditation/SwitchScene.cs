using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public int sceneNumber;
    
    public void LoadScene(int sceneNumber)
    {
        Indestructable.instance.prevScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneNumber);
    }
}
