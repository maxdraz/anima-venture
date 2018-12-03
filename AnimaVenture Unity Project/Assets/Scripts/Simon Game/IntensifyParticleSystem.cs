using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensifyParticleSystem : MonoBehaviour {

    ParticleSystem ps;

    private void Awake()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Clicked");
            StartCoroutine(Intensify(1,3, 2.5f));
        }
    }

    public IEnumerator Intensify(float originalSpeed, float newSpeed, float intensifyForTime)
    {
        var main = ps.main;
        main.startSpeed = newSpeed;
        yield return new WaitForSeconds(intensifyForTime);
        main.startSpeed = originalSpeed;



        //    Debug.Log("got called");
        //   var emission = ps.emission;
        //    ParticleSystem.Burst burst = new ParticleSystem.Burst();
        //    burst.count = count;
        //    burst.cycleCount = cycleCount;
        //burst.repeatInterval = repeatInterval;
        //burst.time = 0.25f;

        //    emission.SetBurst(0, burst);

        //Debug.Log(burst.cycleCount * burst.repeatInterval);

        //    yield return new WaitForSeconds(burst.cycleCount * burst.repeatInterval);

        //    burst.count = 0;

        //    emission.SetBurst(0, burst);

    }

}
