using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{ 
    public float duration = 0.7f;
    public float speed = 20f;
    public float magnitude = 1f;

    Vector3 originalOffset;
    public bool shakeOnStart = false;
    public KeyCode shakeButton;

    void Start()
    {
        originalOffset = transform.localPosition;
        if (shakeOnStart)
            PlayShake();
    }
    
    void Update()
    {        
        if (Input.GetKeyDown(shakeButton))
        {
           PlayShake();
        }
    }

    //This function is used outside (or inside) the script
    public void PlayShake()
    {
        PlayShake(speed, duration, magnitude);
    }

    public void PlayShake(float _speed, float _duration, float _magnitude)
    {
        currentDuration = _duration;
        currentMagnitude = _magnitude;
        currentSpeed = _speed;

        StopAllCoroutines();
        StartCoroutine("Shake");
    }

    float currentSpeed;
    float currentDuration;
    float currentMagnitude;

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        float randomStart = Random.Range(-1000.0f, 1000.0f);
        
        while (elapsed < currentDuration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / currentDuration;

            float damper = 1.0f - Mathf.Clamp(1.5f * percentComplete - 1.0f, 0.0f, 1.0f);
            float alpha = randomStart + (currentSpeed * currentDuration) * percentComplete;

            float x = Mathf.PerlinNoise(alpha, 0.0f) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0.0f, alpha) * 2.0f - 1.0f;

            x *= currentMagnitude * damper;
            y *= currentMagnitude * damper;

            transform.localPosition = originalOffset + new Vector3(x, y, 0);

            yield return 0;
        }

       transform.localPosition = Vector3.Lerp(transform.localPosition,  originalOffset, Time.deltaTime * 5f);
    }
}