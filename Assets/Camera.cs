using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float height = (float)(0.5);
    public int[,] positionMatrix;
    float time_elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        positionMatrix = new int[50,50];
        positionMatrix[1,0] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time_elapsed += Time.deltaTime;
        if (time_elapsed >= 1)
        {
            time_elapsed = 0;
            moveForward();
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
                    positionMatrix[i, j + 1] = 1;
                    positionMatrix[i, j] = 0;
                    break;
                }
            }
        }
    }
}
