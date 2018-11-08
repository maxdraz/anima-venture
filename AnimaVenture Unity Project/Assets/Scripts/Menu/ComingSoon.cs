using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour {

    public GameObject comingSoon;
    public GameObject rainforest;
    SpriteRenderer display;
    SpriteRenderer kingdom;
    SphereCollider detect;
    float speed = .1f;
    float alpha;
    float yPos;

	// Use this for initialization
	void Start ()
    {
        display = GetComponent<SpriteRenderer>();
        Color c = display.material.color;
        c.a = 0f;
        display.material.color = c;
        detect = GetComponent<SphereCollider>();
        comingSoon.SetActive(false);
        rainforest.SetActive(false);
    }

    private void Awake()
    {
      
    }

    // Update is called once per frame
    void Update ()
    {
        if (detect.radius < 0.77f)
        {
            detect.radius = detect.radius + 0.01f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Forest")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Rainforest")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            rainforest.SetActive(true);
        }

        if (other.gameObject.tag == "Desert")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Mountain")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Polar")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Jungle")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Forest")
        {
            StartCoroutine("FadeOut");
            comingSoon.SetActive(false);
        }

        if (other.gameObject.tag == "Rainforest")
        {
            StartCoroutine("FadeOut");
            rainforest.SetActive(false);
        }

        if (other.gameObject.tag == "Desert")
        {
            StartCoroutine("FadeOut");
            comingSoon.SetActive(false);
        }

        if (other.gameObject.tag == "Mountain")
        {
            StartCoroutine("FadeOut");
            comingSoon.SetActive(false);
        }

        if (other.gameObject.tag == "Polar")
        {
            StartCoroutine("FadeOut");
            comingSoon.SetActive(false);
        }

        if (other.gameObject.tag == "Jungle")
        {
            StartCoroutine("FadeOut");
            comingSoon.SetActive(false);
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
