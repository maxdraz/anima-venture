using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegraph_Simon : MonoBehaviour {
    [SerializeField] float lightUpForSeconds = 2f;
    //Sprite renderer reference (only for prototype)
    SpriteRenderer sRenderer;
    Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    // Use this for initialization
    void Start () {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        //(Prototype) set alpha value to half
        ResetTelegraph();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //method for what happens when time to telegraph colour
    public IEnumerator DisplayTelegraph(float t)
    {
        
        //this will be changed later to fit our flying stars
        sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            1.0f);
        animation.clip = animation.GetClip("TelegraphAnimation");
        animation.Play();
        yield return new WaitForSeconds(t);

        ResetTelegraph();
    }

    public void ResetTelegraph()
    {
        sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            0.5f);
        animation.clip = animation.GetClip("TelegraphAnimationShrink");
        animation.Play();
    }

}
