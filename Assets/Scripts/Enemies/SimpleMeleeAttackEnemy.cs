﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeAttackEnemy : BasicEnemy
{
    public float attackLerpValue;

    public int damage;
    [Range(1, 7)] public int attackInterval;
    [Range(0, 7)] public int startDelay;

    private Vector2 targetPos;
    private bool isAttacking;

    private int x1;
    private int x2;

    private int delayTimer;
    private int stayTimer;
    private int attackTimer;

    private int lastPosX;

    void Start()
    {
        x1 = xPos;
        lastPosX = xPos;
        x2 = xPos - 1;
        stayTimer = 0;
        attackTimer = 0;
        delayTimer = startDelay;
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
        if (delayTimer > 0)
        {
            delayTimer--;
            return;
        }
        if (attackTimer > 0)
        {
            attackTimer++;
            if (attackTimer > attackInterval)
            {
                attackTimer = 0;
            }
        }
        if (!isAttacking)
        {
            if (attackTimer == 0)
            {
                DetectPlayer();
            }
            if (!isAttacking)
            {
                Move();
            }
        }
    }

    void DetectPlayer()
    {
        PlayerGridMovement player = GameManager.instance.player.GetComponent<PlayerGridMovement>();
        if (xPos == player.xPos && yPos == player.yPos && player.IsPlayerInActualPosition())
        {
            isAttacking = true;
            attackTimer++;
        }
        else if (xPos + 1 == player.xPos && yPos == player.yPos && xPos == x2 && player.IsPlayerInActualPosition())
        {
            isAttacking = true;
            attackTimer++;

        }
        else if (xPos - 1 == player.xPos && yPos == player.yPos && xPos == x1 && player.IsPlayerInActualPosition())
        {
            isAttacking = true;
            attackTimer++;
        }
        if (isAttacking)
        {
            targetPos = player.transform.position;
        }
    }

    void Move()
    {
        lastPosX = xPos;
        if (!isRaged)
        {
            if (stayTimer == 0)
            {
                if (xPos == x1)
                {
                    xPos = x2;
                }
                else
                {
                    xPos = x1;
                }
                stayTimer++;
            }
            else
            {
                stayTimer = 0;
            }
        }
        else
        {
            if (xPos == x1)
            {
                xPos = x2;
            }
            else
            {
                xPos = x1;
            }
        }
    }

    void CauseDamage()
    {
        GameManager.instance.player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerShield"))
        {
            xPos = lastPosX;
            if (isAttacking)
            {
                this.TakeDamage(damage);
                isAttacking = false;
            }
        }
        if (collision.tag.Equals("Player"))
        {
            CauseDamage();
        }
    }
}
