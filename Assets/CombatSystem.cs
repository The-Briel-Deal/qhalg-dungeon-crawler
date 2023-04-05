using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{

    private float timeSinceLastDefend = 0;
    private float timeSinceLastAttack = 0;

    //parameters
    public float timeBetweenAttacks = 1;
    public float timeBetweenDefends = 1.5f;
    public int hitsToKill = 5;

    //variables based on pre-existing game objects and components.
    public GameObject attackButton;
    public GameObject defendButton;
    public Canvas canvas;

    public void combatUpdate() {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            spawnButton(attackButton);
        }
        timeSinceLastDefend += Time.deltaTime;
        if (timeSinceLastDefend >= timeBetweenDefends)
        {
            spawnButton(defendButton);
        }
    }

    public void spawnButton(GameObject button)
    {   
        GameObject myButton = Instantiate(button, canvas.transform.position, canvas.transform.rotation);
        //Set the new button in a random position between the screen width min and max.
        //But make sure to also restrict within the dimensions of the buttons, as done here.
        //Fade in/fade out code is within the buttons.
        var rectDims = myButton.GetComponent<RectTransform>().rect;
        myButton.transform.position = new Vector3(Random.Range(0 + rectDims.width, Screen.width - rectDims.width),
            Random.Range(0 + rectDims.height, Screen.height - rectDims.height), 0);
        myButton.transform.SetParent(canvas.transform);

        //change whatever counter you need to based on which of the two buttons it is.
        if (button == attackButton) timeSinceLastAttack -= timeBetweenAttacks;
        else if (button == defendButton)
        {
            timeSinceLastDefend -= timeBetweenDefends;
            //5 is a temp value, change it to the monster's damage
            myButton.GetComponent<DefendButton>().damage = 5;
        }

    }

    public void handleAttack()
    {
        print("Attack pressed!");
        hitsToKill--;

        if (hitsToKill <= 0)
        {
            Destroy(gameObject);
            print("The monster was defeated!!");
        }
        
    }
    public void handleDefend()
    {
        print("defend pressed, damage prevented!");
    }
}
