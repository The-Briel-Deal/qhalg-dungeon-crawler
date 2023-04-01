using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int[,] positionMatrix;
    float time_elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        positionMatrix = new int[4,4];
        positionMatrix[0,0] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time_elapsed += Time.deltaTime;
        if (time_elapsed >= 1)
        {
            print("hit");
            time_elapsed = 0;
            for (int i = 0; i < positionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < positionMatrix.GetLength(1); j++)
                {
                    print(i);
                    print(j);
                    if (positionMatrix[i, j] == 1)
                    {
                        positionMatrix[i,j+1] = 1;
                        positionMatrix[i, j] = 0;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
             for(int j = 0; j < positionMatrix.GetLength(1); j++)
             {
                if (positionMatrix[i, j] == 1)
                {
                    Vector3 newPos = new Vector3();
                    newPos.x = 5 + 10 * i;
                    newPos.z = 5 + 10 * j;
                    newPos.y = 4;
                    transform.position = newPos;
                }
             }
        }
    }
}
