using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySway : MonoBehaviour
{
    Quaternion sourcerot;
    // Start is called before the first frame update
    void Start()
    {
        sourcerot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float flow = Mathf.Cos(Time.realtimeSinceStartup * 2);
        var flowRot = new Vector3(0, flow * 1/20, 0);
        transform.Rotate(flowRot);
    }
}
