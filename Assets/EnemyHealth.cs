using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject CombatSystem;
    public GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (PlayerCamera.GetComponent<Camera>().inCombat)
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = $"Enemy Health: {CombatSystem.GetComponent<CombatSystem>().hitsToKill}";
        }
    else
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }
}
