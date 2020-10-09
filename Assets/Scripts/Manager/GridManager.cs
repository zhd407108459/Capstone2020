using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public Vector2 gridSize;
    public Vector2 initialPos;
    public int rowGridCount;
    public int columnGridCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
    }

    void Update()
    {

    }
}
