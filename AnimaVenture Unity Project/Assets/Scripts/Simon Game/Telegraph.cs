using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegraph : MonoBehaviour {

    [Range(0, 3)]
    public int colourIndex;
    public List<Sprite> symbolSprites;
    public List<Color> glowColours;

    SpriteRenderer sr;
    public GameObject glow;
    public ParticleSystem ps;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void OnEnable()
    {
        sr.sprite = symbolSprites[colourIndex];
        glow.GetComponent<SpriteRenderer>().color = glowColours[colourIndex];
        var main = ps.main;
        main.startColor = glowColours[colourIndex];
    }
}
