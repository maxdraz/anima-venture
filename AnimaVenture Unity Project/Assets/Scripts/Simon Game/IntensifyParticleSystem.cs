using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensifyParticleSystem : MonoBehaviour {

    ParticleSystem ps;
    public float originalSpeed;
    public float newSpeed;
    public float intensifyForTime;

    private void Awake()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
      
    }

    public IEnumerator Intensify()
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
