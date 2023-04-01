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

    private float oldIntensity;
    private float oldRange;
    private float targetIntensity;
    private float targetRange;

    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        NewIntensity();
        NewRange();
    }

    // Update is called once per frame
    void Update()
    {
        lantern.intensity = Mathf.Lerp(lantern.intensity, targetIntensity, t);
        lantern.range = Mathf.Lerp(lantern.range, targetRange, t);

        t += 0.5f * flickerSpeed * Time.deltaTime;
        
        if (t > 1.0f)
        {
            NewIntensity();
            NewRange();
            t = 0.0f;
        }
    }

    void NewIntensity()
    {
        oldIntensity = lantern.intensity;
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }
    void NewRange()
    {
        oldRange = lantern.range;
        targetRange = Random.Range(minRange, maxRange);
    }
}
