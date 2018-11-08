using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour {

    SpriteRenderer display;
    SpriteRenderer kingdom;
    float speed = .1f;
    float alpha;

	// Use this for initialization
	void Start ()
    {
        display = GetComponent<SpriteRenderer>();
        Color c = display.material.color;
        c.a = 0f;
        display.material.color = c;
;
    }
	
	// Update is called once per frame
	void Update ()
    {
     
	}

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Forest")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            display.sprite = kingdom.sprite;
            
        }

        if (other.gameObject.tag == "Rainforest")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            
        }
        if (other.gameObject.tag == "Desert")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
        }

        if (other.gameObject.tag == "Mountain")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
        }

        if (other.gameObject.tag == "Polar")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
        }

        if (other.gameObject.tag == "Jungle")
        {
            Debug.Log("Blyat");
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Forest")
        {
            StartCoroutine("FadeOut");
        }

        if (other.gameObject.tag == "RainForest")
        {
            StartCoroutine("FadeOut");
        }

        if (other.gameObject.tag == "Desert")
        {
            StartCoroutine("FadeOut");
        }

        if (other.gameObject.tag == "Mountain")
        {
            StartCoroutine("FadeOut");
        }

        if (other.gameObject.tag == "Polar")
        {
            StartCoroutine("FadeOut");
        }

        if (other.gameObject.tag == "Jungle")
        {
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeIn()
    {
        for (float t = 0.05f; t <= 1; t += 0.05f)
        {
            Color c = display.material.color;
            c.a = t;
            display.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator FadeOut()
    {
        for (float t = 1f; t >= -0/05f; t -= 0.05f)
        {
            Color c = display.material.color;
            c.a = t;
            display.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
