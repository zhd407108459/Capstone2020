﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridBullet : RhythmObject
{
    public float movementLerpValue;

    public int damage;

    public int xDirection;
    public int yDirection;

    [HideInInspector] public int xPos;
    [HideInInspector] public int yPos;

    private Vector3 targetPos;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (Vector2.Distance(transform.position, targetPos) > 0.0001f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementLerpValue * Time.deltaTime);
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        Move();
    }

    public void SetUp(int x, int y)
    {
        xPos = x;
        yPos = y;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }

    public void Move()
    {
        xPos += xDirection;
        yPos += yDirection;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        if (xPos <= -2 || xPos >= 12 || yPos <= -2 || yPos >= 7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
            {
                collision.GetComponent<BasicEnemy>().TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
            }
            else
            {
                collision.GetComponent<BasicEnemy>().TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
        if (collision.tag.Equals("BossComponent"))
        {
            if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
            {
                GridManager.instance.boss.TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
            }
            else
            {
                GridManager.instance.boss.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
