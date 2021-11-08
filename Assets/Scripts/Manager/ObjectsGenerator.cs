using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();


    public void GenerateObject(int index)
    {
        if(index >= objects.Count)
        {
            Debug.LogError("Wrong index!");
            return;
        }
        Instantiate(objects[index]);
    }
}
