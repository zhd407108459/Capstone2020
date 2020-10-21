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

    [HideInInspector] public bool isPlayerFacingRight;

    private Vector3 targetPos;
    private PlayerAction action;

    void Start()
    {
        transform.position = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        targetPos = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        isPlayerFacingRight = true;
        action = GetComponent<PlayerAction>();
    }

    void Update()
    {
        if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused)
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
            if (GridManager.instance.IsPlatformExist(xPos, yPos + 1))
            {
                SetPos(xPos, yPos + 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetPos(xPos, yPos - 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sprite.transform.localScale = new Vector3(Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            isPlayerFacingRight = true;
            SetPos(xPos + 1, yPos);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.transform.localScale = new Vector3(-Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            isPlayerFacingRight = false;
            SetPos(xPos - 1, yPos);
        }
    }

    public void SetPos(int x, int y)
    {
        if (x < 0)
        {
            xPos = 0;
        }
        else if (x >= GridManager.instance.GetPhaseLength())
        {
            xPos = GridManager.instance.GetPhaseLength() - 1;
            //Temp
            if(GridManager.instance.phaseIndex < GridManager.instance.phases.Count - 1)
            {
                if (GridManager.instance.IsInBattlePhase())
                {
                    if (GridManager.instance.IsEnemyClear())
                    {
                        GridManager.instance.EndCurrentPhase();
                        GridManager.instance.StartNextPhase();
                    }
                }
                else
                {
                    GridManager.instance.EndCurrentPhase();
                    GridManager.instance.StartNextPhase();

                }
                
            }
        }
        else
        {
            xPos = x;
            action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved
        }
        if (y < 0)
        {
            yPos = 0;
        }
        else if (y >= GridManager.instance.battleColumnGridCount)
        {
            yPos = GridManager.instance.battleColumnGridCount - 1;
        }
        else
        {
            int tempY = GridManager.instance.GetFirstLowerPlatformYPosition(xPos, y);
            if(yPos != tempY)
            {
                action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved
            }
            yPos = tempY;
        }
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }
}
