using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOF : MonoBehaviour
{
	SpriteRenderer wofSprite;
	Color color;
	Color startColor;

	public GameObject polar;
	public GameObject rainforest;
	public GameObject desert;
	public GameObject mountain;
	public GameObject jungle;
	public GameObject ocean;

	// Use this for initialization
	void Start()
	{
		wofSprite = gameObject.GetComponent<SpriteRenderer>();
		startColor = wofSprite.color;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Polar")
        {
			color = polar.GetComponent<SpriteRenderer>().color;
			wofSprite.color = color;
            Debug.Log("Polar");
        }

		if (other.gameObject.tag == "Rainforest")
        {
			color = rainforest.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
            Debug.Log("Rainforest");
        }

		if (other.gameObject.tag == "Desert")
        {
			color = desert.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
            Debug.Log("Desert");
        }

		if (other.gameObject.tag == "Mountain")
        {
			color = mountain.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
            Debug.Log("Mountain");
        }

		if (other.gameObject.tag == "Jungle")
        {
			color = jungle.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
            Debug.Log("Jungle");
        }

		if (other.gameObject.tag == "Ocean")
        {
			color = ocean.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
            Debug.Log("Ocean");
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Polar")
        {
			wofSprite.color = startColor;
        }

		if (other.gameObject.tag == "Rainforest")
        {
            wofSprite.color = startColor;
        }

		if (other.gameObject.tag == "Desert")
        {
            wofSprite.color = startColor;
        }

		if (other.gameObject.tag == "Mountain")
        {
            wofSprite.color = startColor;
        }

		if (other.gameObject.tag == "Jungle")
        {
            wofSprite.color = startColor;
        }

		if (other.gameObject.tag == "Ocean")
        {
            wofSprite.color = startColor;
        }
	}
}
