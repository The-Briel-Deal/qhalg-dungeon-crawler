using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float height = (float)(0.5);
    private int[,] positionMatrix;
    // float time_elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        positionMatrix = GameObject.FindGameObjectWithTag("map").GetComponent<Map>().positionMatrix;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveForward();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turn(90);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            turn(-90);
        }
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
             for(int j = 0; j < positionMatrix.GetLength(1); j++)
             {
                if (positionMatrix[i, j] == 1)
                {
                    Vector3 newPos = new Vector3();
                    newPos.x = (float)(.5 + 1 * i);
                    newPos.z = (float)(.5 + 1 * j);
                    newPos.y = height;
                    transform.position = newPos;
                }
             }
        }
    }

    void moveForward()
    {
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                if (positionMatrix[i, j] == 1)
                {
                    float direction = (int)(transform.rotation.eulerAngles.y) / 90;
                    if (direction == 0)
                    {
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i, j + 1] == 2)
                        {
                            return;
                        }
                        positionMatrix[i, j + 1] = 1;
                        positionMatrix[i, j] = 0;
                    } else if (direction == 1)
                    {
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i+1, j] == 2)
                        {
                            return;
                        }
                        positionMatrix[i + 1, j] = 1;
                        positionMatrix[i, j] = 0;
                    } else if (direction == 2)
                    {
                        if (j - 1 < 0)
                        {
                            return;
                        }
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i, j - 1] == 2)
                        {
                            return;
                        }
                        positionMatrix[i, j - 1] = 1;
                        positionMatrix[i, j] = 0;
                    }
                    else if (direction == 3)
                    {
                        if (i - 1 < 0)
                        {
                            return;
                        }
                        // if position we are moving to is a wall, do not move there.
                        if (positionMatrix[i - 1, j] == 2)
                        {
                            return;
                        }
                        positionMatrix[i - 1, j] = 1;
                        positionMatrix[i, j] = 0;
                    }

                    return;
                }
            }
        }
    }
    void turn(int degrees)
    {
        transform.Rotate(0, degrees, 0);
    }
}
