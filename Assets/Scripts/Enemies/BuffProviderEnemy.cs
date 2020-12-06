using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;

public class BuffProviderEnemy : BasicEnemy
{
    public int buffType;//0 = extra health, 1 = heal, 2 = damage powerup

    public float buffValue;

    public GameObject buffPrefab;
    public GameObject buffIconPrefab;

    public float buffRange;

    public int startDelay;
    public int actionInterval;
    public int rageActionInterval;

    public string enemyExtraHealthBuffFXEventPath = "event:/FX/Enemy/FX-EnemyShield";
    public string enemyHealBuffFXEventPath = "event:/FX/Enemy/FX-EnemyShield";
    public string enemyPowerupBuffFXEventPath = "event:/FX/Enemy/FX-EnemyShield";

    private int actionTimer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Activate()
    {
        base.Activate();
        actionTimer = -startDelay;
    }

    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        actionTimer++;
        if ((actionTimer >= actionInterval && !isRaged) || (actionTimer >= rageActionInterval && isRaged))
        {
            actionTimer = 0;
            BuffOthers();
        }
    }

    void BuffOthers()
    {
        if(buffType == 0)
        {
            EventInstance enemyExtraHealthBuffFX;
            enemyExtraHealthBuffFX = RuntimeManager.CreateInstance(enemyExtraHealthBuffFXEventPath);
            enemyExtraHealthBuffFX.start();
        }
        else if (buffType == 1)
        {
            EventInstance enemyHealBuffFX;
            enemyHealBuffFX = RuntimeManager.CreateInstance(enemyHealBuffFXEventPath);
            enemyHealBuffFX.start();
        }
        else if (buffType == 2)
        {
            EventInstance enemyPowerupBuffFX;
            enemyPowerupBuffFX = RuntimeManager.CreateInstance(enemyPowerupBuffFXEventPath);
            enemyPowerupBuffFX.start();
        }
        List<BasicEnemy> enemies = GridManager.instance.GetAllEnemies();
        for(int i = 0; i < enemies.Count; i++)
        {
            if(Vector2.Distance(enemies[i].transform.position, transform.position) <= buffRange && enemies[i].gameObject != this.gameObject)
            {
                BasicEnemy targetEnemy = enemies[i];
                if (targetEnemy != null)
                {
                    GameObject go = Instantiate(buffPrefab, transform.position, transform.rotation);
                    UnityEvent events = new UnityEvent();
                    string tempContent = "";
                    if (buffType == 0)
                    {
                        if(targetEnemy.extraHealth > (int)buffValue)
                        {
                            targetEnemy.extraHealth -= (int)buffValue;
                        }
                        else
                        {
                            targetEnemy.RemoveExtraHealth();
                        }
                        events.AddListener(delegate { ProvideExtraHealth(targetEnemy); });
                        tempContent = ((int)(buffValue)).ToString();
                    }
                    else if(buffType == 1)
                    {
                        events.AddListener(delegate { ProvideHealing(targetEnemy); });
                        tempContent = ((int)(buffValue)).ToString();
                    }
                    else if(buffType == 2)
                    {
                        if(targetEnemy.damageIncreasement > 1.0f + buffValue)
                        {
                            targetEnemy.damageIncreasement -= buffValue;
                        }
                        else
                        {
                            targetEnemy.damageIncreasement = 1.0f;
                        }
                        events.AddListener(delegate { ProvidePowerUp(targetEnemy); });
                        tempContent = ((int)(buffValue * 100)).ToString() + "%";
                    }
                    go.GetComponent<EnemyDeathBuffParticle>().SetUp(events, targetEnemy, buffIconPrefab, tempContent);
                }
            }
        }
    }

    public void ProvideExtraHealth(BasicEnemy target)
    {
        target.GetExtraHealth((int)buffValue);
    }

    public void ProvideHealing(BasicEnemy target)
    {
        target.Recover((int)buffValue);
    }

    public void ProvidePowerUp(BasicEnemy target)
    {
        target.damageIncreasement += buffValue;
    }

    public override void Die()
    {
        base.Die();
        List<BasicEnemy> enemies = GridManager.instance.GetAllEnemies();
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Vector2.Distance(enemies[i].transform.position, transform.position) <= buffRange && enemies[i].gameObject != this.gameObject)
            {
                BasicEnemy targetEnemy = enemies[i];
                if (targetEnemy != null)
                {
                    
                    if (buffType == 0)
                    {
                        if (targetEnemy.extraHealth > (int)buffValue)
                        {
                            targetEnemy.extraHealth -= (int)buffValue;
                        }
                        else
                        {
                            targetEnemy.RemoveExtraHealth();
                        }
                    }
                    else if (buffType == 1)
                    {
                    }
                    else if (buffType == 2)
                    {
                        if (targetEnemy.damageIncreasement > 1.0f + buffValue)
                        {
                            targetEnemy.damageIncreasement -= buffValue;
                        }
                        else
                        {
                            targetEnemy.damageIncreasement = 1.0f;
                        }
                    }
                }
            }
        }
    }
    
}
