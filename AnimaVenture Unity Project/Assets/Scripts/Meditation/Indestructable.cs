using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Indestructable : MonoBehaviour {

    public static Indestructable instance = null;

    public int prevScene = 3;

    public GameObject go;

    // Use this for initialization
    void Awake()
    {
		if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            go = GameObject.Find("Return");
            if(go.GetComponent<MedLoad>().ready != true)
            {
                //go.SetActive(true);
                go.GetComponent<MedLoad>().ready = true;
                Destroy(this.gameObject);
            }
        }
    }

}
