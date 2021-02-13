using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BasicMeleeAttackEnemy : BasicEnemy
{
    public float attackLerpValue;

    //public bool isRandom;
    [Range(1, 7)] public int attackInterval;
    [Range(0, 7)] public int startDelay;

    public string enemyMeleeAttackFXEventPath = "event:/FX/Enemy/FX-EnemyMeleeAttack";
    public string shieldImpactFXEventPath = "event:/FX/Player/FX-ShieldImpact";

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
        if(delayTimer > 0)
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
            if(animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
        else if (xPos + 1 == player.xPos && yPos == player.yPos && player.IsPlayerInActualPosition())
        {
            isAttacking = true;
            attackTimer++;
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }

        }
        else if (xPos - 1 == player.xPos && yPos == player.yPos && player.IsPlayerInActualPosition())
        {
            isAttacking = true;
            attackTimer++;
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
        if (isAttacking)
        {
            EventInstance enemyMeleeAttackFX;
            enemyMeleeAttackFX = RuntimeManager.CreateInstance(enemyMeleeAttackFXEventPath);
            if (SettingManager.instance != null)
            {
                float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                enemyMeleeAttackFX.setVolume(SettingManager.instance.overAllVolume * (1.0f - value));
            }
            enemyMeleeAttackFX.start();

            targetPos = player.transform.position;
        }
    }

    void Move()
    {
        //if (isRandom)
        //{
        //    List<int> xList = new List<int>();
        //    List<int> yList = new List<int>();
        //    xList.Add(xPos);
        //    yList.Add(yPos);
        //    if (GridManager.instance.IsPlatformExist(xPos + 1, yPos))
        //    {
        //        xList.Add(xPos + 1);
        //        yList.Add(yPos);
        //    }
        //    if (GridManager.instance.IsPlatformExist(xPos - 1, yPos))
        //    {
        //        xList.Add(xPos - 1);
        //        yList.Add(yPos);
        //    }
        //    if (GridManager.instance.IsPlatformExist(xPos, yPos + 1))
        //    {
        //        xList.Add(xPos);
        //        yList.Add(yPos + 1);
        //    }
        //    if (GridManager.instance.IsPlatformExist(xPos, yPos - 1))
        //    {
        //        xList.Add(xPos);
        //        yList.Add(yPos - 1);
        //    }
        //    int seed = Random.Range(0, xList.Count);
        //    xPos = xList[seed];
        //    yPos = yList[seed];
        //}
        //else
        //{
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
        //}
    }

    void CauseDamage()
    {
        GameManager.instance.player.GetComponent<PlayerHealth>().TakeDamage((int)(damage * damageIncreasement));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerShield"))
        {
            xPos = lastPosX;
            if (isAttacking)
            {
                EventInstance shieldImpactFX;
                shieldImpactFX = RuntimeManager.CreateInstance(shieldImpactFXEventPath);
                if (SettingManager.instance != null)
                {
                    shieldImpactFX.setVolume(SettingManager.instance.overAllVolume);
                }
                shieldImpactFX.start();

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
