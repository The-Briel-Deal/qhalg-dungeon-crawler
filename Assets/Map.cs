using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int[,] positionMatrix;
    public GameObject skeletonPrefab;
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
        spawnEnemy(1, 3);
    }

    void spawnEnemy(int x, int y)
    {
        positionMatrix[x, y] = 3;
        GameObject skeleton = Instantiate(skeletonPrefab, transform.position, transform.rotation) as GameObject;
        skeleton.transform.position = new Vector3(x+.5f,0,y+.5f);
        skeleton.transform.localScale *= .5f;
        skeleton.transform.Rotate(new Vector3(0, 180, 0));
        skeleton.transform.SetParent(transform);
    }
    void despawnEnemy(int x, int y)
    {
        positionMatrix[x, y] = 0;
    }

    void Update()
    {

    }
}
