using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    private float aliveTime;

    //Parameters
    public float fadeInDuration;
    public float fadeOutTime;
    public float lifespan; //probably should make these max/min later

    //Pre-existing components and gameobjects
    private Image sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();

        //Set sprite alpha to zero
        var sprColor = sprite.color;
        sprColor.a = 0f;
        sprite.color = sprColor;
        //

        //Set up listener
        GetComponent<Button>()
            .onClick
            .AddListener(GameObject.FindGameObjectWithTag("combatSystem")
                .GetComponent<CombatSystem>()
                .handleAttack);
    }

    void Update()
    {
        aliveTime += Time.deltaTime;
        //if the sword button has been alive for less than its fade in time, then go fade it in!
        if (aliveTime < fadeInDuration)
        {
            //fade in! :D
            var sprColor = sprite.color;
            sprColor.a = Mathf.Lerp(0f, 1f, aliveTime / fadeInDuration);
            sprite.color = sprColor;
            //
        }
        //otherwise, if the sword button is 100 percent of the way to its expiration, make it begin to expire
        else if (aliveTime / lifespan >= 1)
        {
            //fade out
            var sprColor = sprite.color;
            //sprite alpha gets lesser with how long it takes to fade out
            sprColor.a -= (Time.deltaTime / fadeOutTime);
            sprite.color = sprColor;

            //if the alpha is less than or equal to zero, destroy the button
            if (sprColor.a <= 0f) Destroy(gameObject);
        }
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }


}
