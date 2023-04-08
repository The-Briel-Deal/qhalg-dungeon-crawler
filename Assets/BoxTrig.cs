using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxTrig : MonoBehaviour
{
    public GameObject health;
    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        health.GetComponent<TextMeshProUGUI>().enabled = false;
        endText.GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("_player").GetComponent<Camera>().enabled = false;
        GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;
    }
}
