using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLantern : MonoBehaviour
{
    [SerializeField] private Light lantern;
    [SerializeField] private float flickerSpeed = 1;
    [SerializeField] private float minIntensity = 1;
    [SerializeField] private float maxIntensity = 2;
    [SerializeField] private float minRange = 0.8f;
    [SerializeField] private float maxRange = 1.2f;
    [SerializeField] private float minTime = 0.5f;
    [SerializeField] private float maxTime = 1.0f;

    private float targetIntensity;
    private float targetRange;
    private float targetTime;

    private float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        NewTime();
        NewIntensity();
        NewRange();
    }

    // Update is called once per frame
    void Update()
    {
        lantern.intensity = Mathf.Lerp(lantern.intensity, targetIntensity, t);
        lantern.range = Mathf.Lerp(lantern.range, targetRange, t);

        t += 0.1f * flickerSpeed * Time.deltaTime;
        
        if (t > targetTime)
        {
            NewIntensity();
            NewRange();
            NewTime();
        }
    }

    void NewIntensity()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }
    void NewRange()
    {
        targetRange = Random.Range(minRange, maxRange);
    }

    void NewTime()
    {
        t = 0.0f;
        targetTime = Random.Range(minTime, maxTime);
    }
}
