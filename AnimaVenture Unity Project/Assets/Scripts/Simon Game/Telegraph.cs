using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegraph : MonoBehaviour {

    [Range(0, 3)]
    public int colourIndex;
    public List<Sprite> symbolSprites;
    public List<Color> glowColours;
    float lifetime;

    [SerializeField] AnimationClip anim;

    SpriteRenderer sr;
    public GameObject glow;
    public ParticleSystem ps;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void OnEnable()
    {
        lifetime = anim.length;
        sr.sprite = symbolSprites[colourIndex];
        glow.GetComponent<SpriteRenderer>().color = glowColours[colourIndex];
        var main = ps.main;
        main.startColor = glowColours[colourIndex];        
    }

    private void Update()
    {
       lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void setColourIndex(int cIndex)
    {
        colourIndex = cIndex;
    }
}
