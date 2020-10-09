using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public GameObject sprite;
    public float movementLerpValue;
    public float actionTolerance;

    public int xPos;
    public int yPos;

    private Vector3 targetPos;

    void Start()
    {
        transform.position = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        targetPos = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }

    void Update()
    {
        if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance)
        {
            Move();
        }
        if (Vector2.Distance(transform.position, targetPos) > 0.0001f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementLerpValue * Time.deltaTime);
        }
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetPos(xPos, yPos + 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetPos(xPos, yPos - 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sprite.transform.localScale = new Vector3(Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            SetPos(xPos + 1, yPos);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.transform.localScale = new Vector3(-Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            SetPos(xPos - 1, yPos);
        }
    }

    public void SetPos(int x, int y)
    {
        if (x < 0)
        {
            xPos = 0;
        }
        else if (x >= GridManager.instance.rowGridCount)
        {
            xPos = GridManager.instance.rowGridCount - 1;
        }
        else
        {
            xPos = x;
        }
        if (y < 0)
        {
            yPos = 0;
        }
        else if (y >= GridManager.instance.columnGridCount)
        {
            yPos = GridManager.instance.columnGridCount - 1;
        }
        else
        {
            yPos = y;
        }
        targetPos = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }
}
