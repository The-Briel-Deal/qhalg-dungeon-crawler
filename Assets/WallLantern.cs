using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLantern : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float flickerSpeed = 1;
    [SerializeField] private float minIntensity = 1;
    [SerializeField] private float maxIntensity = 2;
    [SerializeField] private float minRange = 0.8f;
    [SerializeField] private float maxRange = 1.2f;

    private float targetIntensity;
    private float targetRange;
    // Start is called before the first frame update
    void Start()
    {
        NewValues();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void NewValues()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        targetRange = Random.Range(minRange, maxRange);
    }
}
