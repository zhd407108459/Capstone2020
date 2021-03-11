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

    public float easyDifficultyBounceOffDamageOffset = 3.0f;
    public float normalDifficultyBounceOffDamageOffset = 2.0f;

    public string enemyMeleeAttackFXEventPath = "event:/FX/Enemy/FX-EnemyMeleeAttack";
    public string shieldImpactFXEventPath = "event:/FX/Player/FX-ShieldImpact";

    public GameObject attackTip;

    private Vector2 targetPos;
    private bool isAttacking;
    private bool isReadyAttack;

    private int x1;
    private int x2;

    private int delayTimer;
    private int stayTimer;
    private int attackTimer;

    private int lastPosX;

    private int initialPosX;

    void Start()
    {
        x1 = xPos;
        lastPosX = xPos;
        x2 = xPos - 1;
        initialPosX = x1;
        stayTimer = 0;
        attackTimer = 0;
        delayTimer = startDelay;
        attackTip.SetActive(false);
        isAttacking = false;
        isReadyAttack = false;
    }

    public override void Activate()
    {
        base.Activate();
        xPos = initialPosX;
        x1 = initialPosX;
        lastPosX = initialPosX;
        x2 = initialPosX - 1;
        stayTimer = 0;
        attackTimer = 0;
        delayTimer = startDelay;
        attackTip.SetActive(false);
        isAttacking = false;
        isReadyAttack = false;
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
                EventInstance enemyMeleeAttackFX;
                enemyMeleeAttackFX = RuntimeManager.CreateInstance(enemyMeleeAttackFXEventPath);
                if (SettingManager.instance != null)
                {
                    float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    enemyMeleeAttackFX.setVolume(SettingManager.instance.overAllVolume * (1.0f - value));
                }
                enemyMeleeAttackFX.start();

                attackTip.SetActive(false);
                isAttacking = false;
                if (IsTouchingPlayer())
                {
                    CauseDamage();
                }
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
        if (isReadyAttack)
        {
            isAttacking = true;
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            isReadyAttack = false;
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
        if (!isAttacking && !isReadyAttack)
        {
            if (attackTimer == 0)
            {
                DetectPlayer();
            }
            if (!isAttacking && !isReadyAttack)
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
            //isAttacking = true;
            isReadyAttack = true;
            attackTimer++;
        }
        else if (xPos + 1 == player.xPos && yPos == player.yPos && player.IsPlayerInActualPosition())
        {
            //isAttacking = true;
            isReadyAttack = true;
            attackTimer++;

        }
        else if (xPos - 1 == player.xPos && yPos == player.yPos && player.IsPlayerInActualPosition())
        {
            //isAttacking = true;
            isReadyAttack = true;
            attackTimer++;
        }
        if (isReadyAttack)
        {
            attackTip.SetActive(true);
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

    bool IsTouchingPlayer()
    {
        Collider2D[] cos = Physics2D.OverlapBoxAll(transform.position, new Vector2(GetComponent<BoxCollider2D>().size.x, GetComponent<BoxCollider2D>().size.y), 0);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Player"))
            {
                return true;
            }
        }
        return false;
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

                if (SettingManager.instance != null)
                {
                    if (SettingManager.instance.difficulty == 1)
                    {
                        this.TakeDamage((int)(damage * normalDifficultyBounceOffDamageOffset));
                    }
                    else if (SettingManager.instance.difficulty == 0)
                    {
                        this.TakeDamage((int)(damage * easyDifficultyBounceOffDamageOffset));
                    }
                    else
                    {
                        this.TakeDamage(damage);
                    }
                }
                else
                {
                    this.TakeDamage(damage);
                }
                isAttacking = false;
            }
        }
        //if (collision.tag.Equals("Player"))
        //{
        //    CauseDamage();
        //}
    }
}
