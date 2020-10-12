using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeAttackEnemy : BasicEnemy
{
    public float attackLerpValue;

    private Vector2 targetPos;
    private bool isAttacking;

    void Start()
    {
    }

    void Update()
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        if (isAttacking)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, attackLerpValue * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                isAttacking = false;
            }
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y), attackLerpValue * Time.deltaTime);
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        if (!isAttacking)
        {
            DetectPlayer();
            if (!isAttacking)
            {
                Move();
            }
        }
    }

    void DetectPlayer()
    {
        PlayerGridMovement player = GameManager.instance.player.GetComponent<PlayerGridMovement>();
        if (xPos == player.xPos && yPos == player.yPos)
        {
            isAttacking = true;
        }
        else if (xPos + 1 == player.xPos && yPos == player.yPos)
        {
            isAttacking = true;
        }
        else if (xPos - 1 == player.xPos && yPos == player.yPos)
        {
            isAttacking = true;
        }
        if (isAttacking)
        {
            targetPos = player.transform.position;
        }
    }

    void Move()
    {
        List<int> xList = new List<int>();
        List<int> yList = new List<int>();
        xList.Add(xPos);
        yList.Add(yPos);
        if (GridManager.instance.IsPlatformExist(xPos + 1, yPos))
        {
            xList.Add(xPos + 1);
            yList.Add(yPos);
        }
        if (GridManager.instance.IsPlatformExist(xPos - 1, yPos))
        {
            xList.Add(xPos - 1);
            yList.Add(yPos);
        }
        if (GridManager.instance.IsPlatformExist(xPos, yPos + 1))
        {
            xList.Add(xPos);
            yList.Add(yPos + 1);
        }
        if (GridManager.instance.IsPlatformExist(xPos, yPos - 1))
        {
            xList.Add(xPos);
            yList.Add(yPos - 1);
        }
        int seed = Random.Range(0, xList.Count);
        xPos = xList[seed];
        yPos = yList[seed];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerShield"))
        {
            isAttacking = false;
        }
    }
}
