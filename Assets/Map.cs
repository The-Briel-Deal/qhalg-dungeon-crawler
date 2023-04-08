using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    // Declare properties
    public int Type { get; set; }
    public GameObject Object { get; set; }

    // Declare constructor(s)
    public GridObject(int type = 0, GameObject gObject = null)
    {
        Object = gObject;
        Type = type;
    }

    // Declare methods
    public void PrintInfo()
    {
        Debug.Log($"Object: {Object}, Type: {Type}");
    }
}

public class Map : MonoBehaviour
{
    public GridObject[,] positionMatrix;
    public GameObject skeletonPrefab;
    public GameObject eyePrefab;
    public GameObject elfPrefab;
    void Start()
    {
        positionMatrix = new GridObject[50, 50];
        for (int i = 0; i < positionMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < positionMatrix.GetLength(1); j++)
            {
                positionMatrix[i, j] = new GridObject();
                if (!Physics.Raycast(new Vector3((float)(0.5 + 1*i), 1, (float)(0.5 + 1*j)), Vector3.down, 20f))
                {
                    positionMatrix[i, j] = new GridObject(2);
                    //print(string.Format("I: {0}, J: {1}, Bool: {2}", i, j, false));
                } else
                {
                    //print(string.Format("I: {0}, J: {1}, Bool: {2}", i, j, true));
                }
            }
        }
        positionMatrix[1, 0].Type = 1;
        spawnEnemy(eyePrefab, 1, 3, 0);
        spawnEnemy(elfPrefab, 6, 6, 90);
        spawnEnemy(eyePrefab, 8, 3, 0);
    }

    void spawnEnemy(GameObject prefab, int x, int y, int rotation)
    {
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
        obj.transform.position = new Vector3(x+.5f,0,y+.5f);

        obj.transform.Rotate(new Vector3(-90, 180 + rotation, 0));
        obj.transform.Translate(new Vector3(0, 0.5f, 0), Space.World);
        positionMatrix[x, y].Object = obj;

        positionMatrix[x, y].Type = 3;


    }
    public void despawnEnemy(int x, int y)
    {
        positionMatrix[x, y].Type = 0;
        Destroy(positionMatrix[x, y].Object);
        positionMatrix[x, y].Object = null;
    }
}
