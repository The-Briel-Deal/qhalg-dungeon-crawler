using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    float timeSinceLastAttack = 0;
    public float timeBetweenAttacks = 1;
    float timeSinceLastDefend = 0;
    public float timeBetweenDefends = 1.5f;
    public GameObject attackButton;
    public GameObject defendButton;
    public Canvas canvas;
    public void combatUpdate() {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            timeSinceLastAttack -= timeBetweenAttacks;
            GameObject myButton = Instantiate(attackButton, canvas.transform.position, canvas.transform.rotation) as GameObject;
            myButton.transform.position = new Vector3(myButton.transform.position.x + Random.Range(-500,500), myButton.transform.position.y + Random.Range(-500, 500), 0);
            myButton.transform.SetParent(canvas.transform);
        }
        timeSinceLastDefend += Time.deltaTime;
        if (timeSinceLastDefend >= timeBetweenDefends)
        {
            timeSinceLastDefend -= timeBetweenDefends;
            GameObject myButton = Instantiate(defendButton, canvas.transform.position, canvas.transform.rotation) as GameObject;
            myButton.transform.position = new Vector3(myButton.transform.position.x + Random.Range(-500, 500), myButton.transform.position.y + Random.Range(-500, 500), 0);
            myButton.transform.SetParent(canvas.transform);
        }
    }
}
