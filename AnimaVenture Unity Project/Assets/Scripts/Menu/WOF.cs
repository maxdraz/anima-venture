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

	public Animation KingdomNameTextAnim;

    //Snapping
    public Transform menu;
    public Quaternion currAngle;
    public Quaternion lastAngle;
    public Rigidbody rb;
    public float z;
    bool spinning = false;
    public float vel;
    float speed = 5f;

	// Use this for initialization
	void Start()
	{
		wofSprite = gameObject.GetComponent<SpriteRenderer>();       
        //currAngle = menu.transform.rotation;
    }

    private void Awake()
    {
        StartCoroutine(Snap());
    }

    private void OnEnable()
    {
        StartCoroutine(Snap());
    }

    // Update is called once per frame
    void Update()
	{
        z = menu.transform.eulerAngles.z;
        currAngle = menu.transform.rotation;
        vel = rb.angularVelocity.z;

        if (vel < 0)
        {
            vel = vel * -1;
        }
        //StartCoroutine(Snap());

        if (currAngle == lastAngle && z > 30 && z < 90 && vel <= .1f)
        {
            StartCoroutine(Mountain(1));
        }

        if (currAngle == lastAngle && z > 90 && z < 150 && vel <= .1f)
        {
            StartCoroutine(Desert(1));
        }

        if (currAngle == lastAngle && z > 150 && z < 210 && vel <= .1f)
        {
            StartCoroutine(Ocean(1));
        }

        if (currAngle == lastAngle && z > 210 && z < 270 && vel <= .1f)
        {
            StartCoroutine(Jungle(1));
        }

        if (currAngle == lastAngle && z > 270 && z < 330 && vel <= .1f)
        {
            StartCoroutine(Polar(1));
        }

        if (currAngle == lastAngle && z > 330 && vel <= .1f)
        {
            StartCoroutine(Forest1(1));
        }
        if (currAngle == lastAngle && z < 30 && vel <= .1f)
        {
            StartCoroutine(Forest(1));
        }
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Polar")
        {
			color = polar.GetComponent<SpriteRenderer>().color;
			wofSprite.color = color;
        }

		if (other.gameObject.tag == "Rainforest")
        {
			color = rainforest.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
        }

		if (other.gameObject.tag == "Desert")
        {
			color = desert.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
        }

		if (other.gameObject.tag == "Mountain")
        {
			color = mountain.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
        }

		if (other.gameObject.tag == "Jungle")
        {
			color = jungle.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
        }

		if (other.gameObject.tag == "Ocean")
        {
			color = ocean.GetComponent<SpriteRenderer>().color;
            wofSprite.color = color;
        }

		KingdomNameTextAnim.clip = KingdomNameTextAnim.GetClip ("KingdomNameTextFadeIn");
		KingdomNameTextAnim.Play ();
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

		KingdomNameTextAnim.clip = KingdomNameTextAnim.GetClip ("KingdomNameTextFadeOut");
		KingdomNameTextAnim.Play ();
	}

    IEnumerator Snap()
    {
        float t = 5f;
        {
            while(true)
            {
                if(currAngle == lastAngle)
                {
                    Debug.Log("Same");
                }
                yield return new WaitForSeconds(t);
                lastAngle = currAngle;
            }
        }
    }

    IEnumerator Mountain(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 60);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Desert(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 120);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Ocean(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 180);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Jungle(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 240);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Polar(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 300);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Forest(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 0);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

    IEnumerator Forest1(float duration)
    {
        Vector3 startRotation = menu.transform.eulerAngles;
        Vector3 endRotation = new Vector3(0, 0, 360);
        float t = 0;
        while (t < 1)
        {
            menu.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        menu.transform.eulerAngles = endRotation;
    }

}
