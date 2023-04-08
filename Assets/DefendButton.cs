using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendButton : MonoBehaviour
{
    private float aliveTime;
    private float shakeIntensity = 1f;

    //set this via the combat system
    public int damage;

    //Parameters
    public float fadeInTime;
    public float lifespan; //probably should make these max/min later
    public float collapseTime;
    public float shakeIncreaseScale;

    //Pre-existing components and gameobjects
    private Image sprite;
    private Vector3 rootPos;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
        rootPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

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
                .handleDefend);
    }

    void Update()
    {
        aliveTime += Time.deltaTime;
        //if the shield button has been alive for less than its fade in time, then go fade it in!
        if (aliveTime < fadeInTime)
        {
            //fade in! :D
            var sprColor = sprite.color;
            sprColor.a = Mathf.Lerp(0f, 1f, aliveTime / fadeInTime);
            sprite.color = sprColor;
            //
        }
        //otherwise, if the shield button is 100 percent of the way to its expiration,
         
        else if (aliveTime / lifespan >= 1)
        {
            //begin to shake -- now it's once every 6 frames at 60fps
            if (Time.frameCount % 10 == 0)
                transform.position = new Vector3(rootPos.x + (Random.Range(-2f, 2f) * shakeIntensity), rootPos.y + (Random.Range(-2f, 2f) * shakeIntensity));

            //gradually increase the shaking intensity
            shakeIntensity += Time.deltaTime * shakeIncreaseScale;

            collapseTime -= Time.deltaTime * 1.5f;

            if (collapseTime <= 0)
            {
                player.GetComponent<PlayerData>().Health -= damage;
                print("Ouch! Player takes damage!");
                Destroy(gameObject);
            }

           
        }
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }

}
