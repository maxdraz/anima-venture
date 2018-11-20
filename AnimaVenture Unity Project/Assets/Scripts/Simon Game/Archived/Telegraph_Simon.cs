using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegraph_Simon : MonoBehaviour {
    [SerializeField] int audioIndex;
    [SerializeField] float timeToMove;
    [SerializeField] float lightUpForSeconds = 2f;
    //Sprite renderer reference (only for prototype)
    SpriteRenderer sRenderer;
    Animation animation;
    AudioManager AM;

    private void Awake()
    {
        animation = GetComponent<Animation>();
        AM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);

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
        gameObject.SetActive(true);
        //Follow the parabola and wait until it finishes
        GetComponent<ParabolaController>().FollowParabola();
        yield return new WaitForSeconds(timeToMove);
        //this will be changed later to fit our flying stars
        sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            1.0f);
        //play sound and animation
        AM.PlayClip(audioIndex);
        animation.clip = animation.GetClip("TelegraphAnimation");
        animation.Play();
        yield return new WaitForSeconds(t);

        ResetTelegraph();
        
    }

    public void ResetTelegraph()
    {
       /*sRenderer.color = new Color(sRenderer.color.r,
            sRenderer.color.g,
            sRenderer.color.b,
            0.5f);
        animation.clip = animation.GetClip("TelegraphAnimationShrink");
        animation.Play();*/
        transform.position = GetComponent<ParabolaController>().ParabolaRoot.transform.position;
        gameObject.SetActive(false);
    }

}
