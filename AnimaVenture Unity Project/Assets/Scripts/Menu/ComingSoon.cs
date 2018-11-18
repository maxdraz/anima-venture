﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour {

    public GameObject comingSoon;
    public GameObject rainforest;
    public GameObject journey;

    public GameObject glow;

    SpriteRenderer display;
    SpriteRenderer kingdom;

    SpriteRenderer glowSprite;

    Color g;

    CircleCollider2D center;
    SphereCollider detect;
    float speed = .1f;
    float alpha;
    float yPos;

    public GameObject forest;
    public GameObject mountain;
    public GameObject ocean;
    public GameObject polar;
    public GameObject desert;
    public GameObject jungle;

    // Use this for initialization
    void Start ()
    {
        display = GetComponent<SpriteRenderer>();
        glowSprite = glow.GetComponent<SpriteRenderer>();
        center = journey.GetComponent<CircleCollider2D>();

        Color g = glowSprite.material.color;
        glowSprite.color = new Color(115f, 55f, 173f, 1f);
        Color c = display.material.color;
        c.a = 0f;
        display.material.color = c;
        detect = GetComponent<SphereCollider>();
        center.enabled = false;
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
            glowSprite.sprite = forest.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = forest.GetComponent<SpriteRenderer>().color;
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Rainforest")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            glowSprite.sprite = ocean.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = ocean.GetComponent<SpriteRenderer>().color;
            StartCoroutine("FadeIn");
            center.enabled = true;
            display.sprite = kingdom.sprite;
            rainforest.SetActive(true);
        }

        if (other.gameObject.tag == "Desert")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            glowSprite.sprite = desert.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = desert.GetComponent<SpriteRenderer>().color;
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Mountain")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            glowSprite.sprite = mountain.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = mountain.GetComponent<SpriteRenderer>().color;
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Polar")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            glowSprite.sprite = polar.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = polar.GetComponent<SpriteRenderer>().color;
            StartCoroutine("FadeIn");
            display.sprite = kingdom.sprite;
            comingSoon.SetActive(true);
        }

        if (other.gameObject.tag == "Jungle")
        {
            kingdom = other.GetComponent<SpriteRenderer>();
            glowSprite.sprite = jungle.GetComponent<SpriteRenderer>().sprite;
            glowSprite.color = jungle.GetComponent<SpriteRenderer>().color;
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
            center.enabled = false;
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
            Color g = glowSprite.material.color;
            g.a = t;
            glowSprite.material.color = g;
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
            Color g = glowSprite.material.color;
            g.a = t;
            glowSprite.material.color = g;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
