using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>()
            .onClick
            .AddListener(GameObject.FindGameObjectWithTag("combatSystem")
                .GetComponent<CombatSystem>()
                .handleAttack);
    }
}
