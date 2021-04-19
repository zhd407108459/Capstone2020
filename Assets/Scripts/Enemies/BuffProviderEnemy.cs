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

    public string enemyExtraHealthBuffFXEventPath = "event:/FX/Enemy/FX-EnemyBuff";
    public string enemyHealBuffFXEventPath = "event:/FX/Enemy/FX-EnemyBuff";
    public string enemyPowerupBuffFXEventPath = "event:/FX/Enemy/FX-EnemyBuff";

    private string enemySecondBuffFXEventPath = "event:/FX/Enemy/FX-EnemyBuff2_2";

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
        animator.SetTrigger("Attack");
        if(GridManager.instance.levelIndex == 2)
        {
            int index = BeatsManager.instance.GetIndexToNearestBeat();
            if ((index >= 56 && index <= 119) || (index >= 184 && index <= 247)) 
            {
                EventInstance enemySecondBuffFX;
                enemySecondBuffFX = RuntimeManager.CreateInstance(enemySecondBuffFXEventPath);
                if (SettingManager.instance != null)
                {
                    float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    enemySecondBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                }
                enemySecondBuffFX.start();
            }
            else
            {
                if (buffType == 0)
                {
                    EventInstance enemyExtraHealthBuffFX;
                    enemyExtraHealthBuffFX = RuntimeManager.CreateInstance(enemyExtraHealthBuffFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                        enemyExtraHealthBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                    }
                    enemyExtraHealthBuffFX.start();
                }
                else if (buffType == 1)
                {
                    EventInstance enemyHealBuffFX;
                    enemyHealBuffFX = RuntimeManager.CreateInstance(enemyHealBuffFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                        enemyHealBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                    }
                    enemyHealBuffFX.start();
                }
                else if (buffType == 2)
                {
                    EventInstance enemyPowerupBuffFX;
                    enemyPowerupBuffFX = RuntimeManager.CreateInstance(enemyPowerupBuffFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                        enemyPowerupBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                    }
                    enemyPowerupBuffFX.start();
                }
            }
        }
        else
        {
            if (buffType == 0)
            {
                EventInstance enemyExtraHealthBuffFX;
                enemyExtraHealthBuffFX = RuntimeManager.CreateInstance(enemyExtraHealthBuffFXEventPath);
                if (SettingManager.instance != null)
                {
                    float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    enemyExtraHealthBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                }
                enemyExtraHealthBuffFX.start();
            }
            else if (buffType == 1)
            {
                EventInstance enemyHealBuffFX;
                enemyHealBuffFX = RuntimeManager.CreateInstance(enemyHealBuffFXEventPath);
                if (SettingManager.instance != null)
                {
                    float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    enemyHealBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                }
                enemyHealBuffFX.start();
            }
            else if (buffType == 2)
            {
                EventInstance enemyPowerupBuffFX;
                enemyPowerupBuffFX = RuntimeManager.CreateInstance(enemyPowerupBuffFXEventPath);
                if (SettingManager.instance != null)
                {
                    float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    enemyPowerupBuffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                }
                enemyPowerupBuffFX.start();
            }
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
        if(enemies == null)
        {
            return;
        }
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
