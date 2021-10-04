using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridBullet : RhythmObject
{
    public float movementLerpValue;

    public int damage;
    public float easyDifficultyDamageOffset;
    public float normalDifficultyDamageOffset;

    public int xDirection;
    public int yDirection;

    public bool isFlipIn180 = false;

    public GameObject sprite;

    public GameObject hitEffectPrefab;

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
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.difficulty == 1)
            {
                damage = (int)(damage * normalDifficultyDamageOffset);
            }
            if (SettingManager.instance.difficulty == 0)
            {
                damage = (int)(damage * easyDifficultyDamageOffset);
            }
        }
    }

    public void SetBulletRotation()
    {
        if (xDirection > 0 && yDirection == 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            return;
        }
        if (xDirection < 0 && yDirection == 0)
        {
            if (!isFlipIn180)
            {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            }
            else
            {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, sprite.transform.localScale.y, sprite.transform.localScale.z);
            }
            return;
        }
        if (xDirection == 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            return;
        }
        if (xDirection == 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
            return;
        }
        if (xDirection > 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            return;
        }
        if (xDirection < 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            return;
        }
        if (xDirection < 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 225.0f);
            return;
        }
        if (xDirection > 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
            return;
        }
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
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, collision.transform.position, Quaternion.identity);
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
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
        if (collision.tag.Equals("BossBomb"))
        {
            Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(GridManager.instance.boss.centerShootPosX * GridManager.instance.gridSize.x, GridManager.instance.boss.centerShootPosY * GridManager.instance.gridSize.y);
            if ((collision.transform.position.x - centerPos.x >= 0 && xDirection <= 0) || (collision.transform.position.x - centerPos.x < 0 && xDirection >= 0))
            {
                collision.GetComponent<EnemyBomb>().AttackedByPlayer(centerPos, true);
            }
            else
            {
                if (collision.transform.position.x - centerPos.x >= 0)
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(5.0f, 0, 0), false);
                }
                else
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(-5.0f, 0, 0), false);
                }
            }
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, collision.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);

        }
    }
}
