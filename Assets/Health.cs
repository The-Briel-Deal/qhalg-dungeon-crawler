using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Health: {GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>().Health}";
    }
}
