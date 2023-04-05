using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    bool inCombat = false;

    public float rotationSpeed;
    float targetRotation = 0;

    private bool rotating = false;

    public float movementSpeed;
    Vector3 targetPosition = new Vector3(0,0,0);

    private bool moving = false;

    private const float height = (float)(0.5);
    private GridObject[,] positionMatrix;
    // float time_elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                if (positionMatrix[i, j].Type == 1)
                {
                    Vector3 newPos = new Vector3();
                    newPos.x = (float)(.5 + 1 * i);
                    newPos.z = (float)(.5 + 1 * j);
                    newPos.y = height;
                    transform.position = newPos;
                    targetPosition = newPos;
                }
            }
        }
        positionMatrix = GameObject.FindGameObjectWithTag("map").GetComponent<Map>().positionMatrix;
    }

    void Update()
    {
        if (positionMatrix == null)
        {
            positionMatrix = GameObject.FindGameObjectWithTag("map").GetComponent<Map>().positionMatrix;
        }
        if (rotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetRotation, 0), step);

            if (transform.rotation.eulerAngles.y == targetRotation)
            {
                rotating = false;
            }
        }
        if (inCombat) {
            handleCombatLoop();
        }else
        {

        if (Input.GetKeyDown(KeyCode.W))
        {
            move(0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move(270);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move(180);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move(90);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turn(90);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            turn(-90);
        }
        }
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                //print(positionMatrix[0,0]);
                if (positionMatrix[i, j].Type == 1)
                {
                    if (positionMatrix[i, j + 1].Type == 3 && !inCombat)
                    {
                        print("going into combat!");
                        initiateCombat();
                    }
                    Vector3 newPos = new Vector3();
                    newPos.x = (float)(.5 + 1 * i);
                    newPos.z = (float)(.5 + 1 * j);
                    newPos.y = height;
                    transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * movementSpeed);
                }
            }
        }
    }

    void initiateCombat()
    {
        GameObject.FindGameObjectWithTag("notificationSystem").GetComponent<NotificationSystem>().notify("Combat Start!");
        inCombat = true;
    }

    void handleCombatLoop() {
        GameObject.FindGameObjectWithTag("combatSystem").GetComponent<CombatSystem>().combatUpdate();

    }


    void move(int directionAdjustment)
    {
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                if (positionMatrix[i, j].Type == 1)
                {
                    float direction = (((int)(transform.rotation.eulerAngles.y)+directionAdjustment) / 90) % 4;
                    print(direction);
                    if (direction == 0)
                    {
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i, j + 1].Type == 2)
                        {
                            print("0");
                            return;
                        }
                        positionMatrix[i, j + 1].Type = 1;
                        positionMatrix[i, j].Type = 0;
                    } else if (direction == 1)
                    {
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i+1, j].Type == 2)
                        {
                            print("1");
                            return;
                        }
                        positionMatrix[i + 1, j].Type = 1;
                        positionMatrix[i, j].Type = 0;
                    } else if (direction == 2)
                    {
                        if (j - 1 < 0)
                        {
                            print("2");
                            return;
                        }
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i, j - 1].Type == 2)
                        {
                            print("3");
                            return;
                        }
                        positionMatrix[i, j - 1].Type = 1;
                        positionMatrix[i, j].Type = 0;
                    }
                    else if (direction == 3)
                    {
                        if (i - 1 < 0)
                        {
                            return;
                        }
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i - 1, j].Type == 2)
                        {
                            return;
                        }
                        positionMatrix[i - 1, j].Type = 1;
                        positionMatrix[i, j].Type = 0;
                    }

                    return;
                }
            }
        }
    }
    

    void turn(int degrees)
    {
        targetRotation += degrees;
        rotating = true;
    }
}
