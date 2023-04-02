using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int[,] positionMatrix;
    void Start()
    {
        positionMatrix = new int[50, 50];
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                if (!Physics.Raycast(new Vector3((float)(0.5 + 1*i), 1, (float)(0.5 + 1*j)), Vector3.down, 20f))
                {
                    positionMatrix[i, j] = 2;
                    print(string.Format("I: {0}, J: {1}, Bool: {2}", i, j, false));
                } else
                {
                    print(string.Format("I: {0}, J: {1}, Bool: {2}", i, j, true));
                }
            }
        }
        positionMatrix[1, 0] = 1;
        positionMatrix[1, 3] = 3;
    }

    void Update()
    {

    }
}
