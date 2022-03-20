using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;
using Steamworks;
using Steamworks.Data;

public class BasicEnemy : RhythmObject
{
    public bool isActivated;

    public int maxHealth;
    public Slider healthSlider;

    public Slider extraHealthSlider;

    public int damage;
    [HideInInspector]public float damageIncreasement;

    public int dealthRattleType;//0 = none, 1 = extra health, 2 = heal, 3 = damage powerup, 4 = rage, 5 = reduce rage time
    public float dealthRattleValue;
    public GameObject deathRattlePrefab;
    public GameObject deathRattleBuffIconPrefab;

    public int xPos;
    public int yPos;
    public GameObject sprite;
    public Animator animator;

    [HideInInspector] public int health;

    [HideInInspector] public bool isMeleeAttacked;
    [HideInInspector] public bool isDashed;

    [HideInInspector] public bool isRaged;

    [HideInInspector] public int extraHealth;
    [HideInInspector] public int maxExtraHealth;

    public string enemyDamagedFXEventPath = "event:/FX/Enemy/FX-EnemyDamaged";
    public string enemyDeathFXEventPath = "event:/FX/Enemy/FX-EnemyDeath";
    public string enemyDeathRattleFXEventPath = "event:/FX/Enemy/FX-EnemyRageBall";

    public int typeID = -1;

    void Start()
    {
        extraHealthSlider.gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        isActivated = true;
        isRaged = false;
        health = maxHealth;
        extraHealth = 0;
        maxExtraHealth = 0;
        damageIncreasement = 1.0f;
        healthSlider.value = (float)health / (float)maxHealth;
        extraHealthSlider.gameObject.SetActive(false);
    }

    public virtual void OnRestart()
    {
        isActivated = false;
        isRaged = false;
        health = maxHealth;
        damageIncreasement = 1.0f;
        healthSlider.value = (float)health / (float)maxHealth;
        extraHealthSlider.gameObject.SetActive(false);
    }

    public void MeleeAttacked()
    {
        isMeleeAttacked = true;
        Invoke("TurnOffIsMeleeAttacked", 0.4f);
    }

    void TurnOffIsMeleeAttacked()
    {
        isMeleeAttacked = false;
    }

    public void Dashed()
    {
        isDashed = true;
        Invoke("TurnOffIsDashed", 0.4f);
    }

    void TurnOffIsDashed()
    {
        isDashed = false;
    }

    public virtual bool TakeDamage(int damage)
    {

        EventInstance enemyDamagedFX;
        enemyDamagedFX = RuntimeManager.CreateInstance(enemyDamagedFXEventPath);
        if (SettingManager.instance != null)
        {
            float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            enemyDamagedFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
        }
        enemyDamagedFX.start();

        Camera.main.GetComponent<CameraShake>().Shake();
        int tempD = damage;
        if(extraHealth > 0 && extraHealthSlider.gameObject.activeSelf)
        {
            if(extraHealth > tempD)
            {
                extraHealth -= tempD;
                extraHealthSlider.value = (float)extraHealth / (float)maxExtraHealth;
                return false;
            }
            else
            {
                tempD -= extraHealth;
                extraHealth = 0;
                maxExtraHealth = 0;
                extraHealthSlider.gameObject.SetActive(false);
            }
        }
        health -= tempD;
        if(health <= 0)
        {
            health = 0;
            healthSlider.value = (float)health / (float)maxHealth;
            Die();
            return true;
        }
        else
        {
            healthSlider.value = (float)health / (float)maxHealth;
            return false;
        }

    }

    public void Recover(int value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        healthSlider.value = (float)health / (float)maxHealth;
    }

    public void GetExtraHealth(int value)
    {
        if(maxExtraHealth == 0)
        {
            maxExtraHealth = value;
            extraHealth = value;
        }
        else
        {
            extraHealth += value;
            if(maxExtraHealth < extraHealth)
            {
                maxExtraHealth = extraHealth;
            }
        }
        extraHealthSlider.value = (float)extraHealth / (float)maxExtraHealth;
        extraHealthSlider.gameObject.SetActive(true);
    }

    public void RemoveExtraHealth()
    {
        maxExtraHealth = 0;
        extraHealth = 0;
        extraHealthSlider.value = 0;
        extraHealthSlider.gameObject.SetActive(false);
    }

    public virtual void Die()
    {
        if (!this.gameObject.activeSelf || !isActivated)
        {
            return;
        }
        GridManager.instance.CheckEnemyCount();

        if(typeID == 4) {
            if(GridManager.instance.GetEnemyCount() == 1)
            {
                CheckLastBeatShieldBuffEnemyAchievement();
            }
        }
        if (GridManager.instance.GetEnemyCount() == 1)
        {
            GridManager.instance.CheckStayRage1MinutesAchievement();
        }

        EventInstance enemyDeathFX;
        enemyDeathFX = RuntimeManager.CreateInstance(enemyDeathFXEventPath);
        if (SettingManager.instance != null)
        {
            float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            enemyDeathFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
        }
        enemyDeathFX.start();

        this.gameObject.SetActive(false);
        if (GridManager.instance.IsEnemyClear())
        {
            GridManager.instance.ShowNextStageIcon();
        }
        if(dealthRattleType != 0)
        {
            EventInstance enemyDeathRattleFX;
            enemyDeathRattleFX = RuntimeManager.CreateInstance(enemyDeathRattleFXEventPath);
            if (SettingManager.instance != null)
            {
                float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                enemyDeathRattleFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
            }
            enemyDeathRattleFX.start();
        }
        if(dealthRattleType > 0 && dealthRattleType < 5)
        {
            BasicEnemy targetEnemy = GridManager.instance.GetRandomEnemy();
            if (targetEnemy != null)
            {
                GameObject go = Instantiate(deathRattlePrefab, transform.position, transform.rotation);
                UnityEvent events = new UnityEvent();
                string tempContent = "";
                if(dealthRattleType == 1)
                {
                    events.AddListener(delegate { DeathRattleExtraHealth(targetEnemy); });
                    tempContent = ((int)(dealthRattleValue)).ToString();
                }
                else if (dealthRattleType == 2)
                {
                    events.AddListener(delegate { DeathRattleHealing(targetEnemy); });
                    tempContent = ((int)(dealthRattleValue)).ToString();
                }
                else if (dealthRattleType == 3)
                {
                    events.AddListener(delegate { DeathRattlePowerUp(targetEnemy); });
                    tempContent = ((int)(dealthRattleValue * 100)).ToString() + "%";
                }
                else if (dealthRattleType == 4)
                {
                    events.AddListener(delegate { DeathRattleRage(targetEnemy); });
                    tempContent = "Rage!";
                }
                go.GetComponent<EnemyDeathBuffParticle>().SetUp(events, targetEnemy, deathRattleBuffIconPrefab, tempContent);
            }
        }
        if(dealthRattleType == 5)
        {
            GridManager.instance.ReduceRageTime(dealthRattleValue);
        }
    }


    public void DeathRattleExtraHealth(BasicEnemy target)
    {
        target.GetExtraHealth((int)dealthRattleValue);
    }

    public void DeathRattleHealing(BasicEnemy target)
    {
        target.Recover((int)dealthRattleValue);
    }

    public void DeathRattlePowerUp(BasicEnemy target)
    {
        target.damageIncreasement += dealthRattleValue;
    }

    public void DeathRattleRage(BasicEnemy target)
    {
        target.isRaged = true;
    }

    private void CheckLastBeatShieldBuffEnemyAchievement()
    {
        //try
        //{
        //    SteamClient.Init(1840150);
        //}
        //catch (System.Exception e)
        //{
        //    // Couldn't init for some reason (steam is closed etc)
        //    Debug.LogError("Failed to init Steam!");
        //}

        if (SteamClient.IsValid)
        {
            var ach = new Achievement("LAST_BEAT_SHIELD_BUFF_ENEMY");
            if (!ach.State)
            {
                ach.Trigger();
            }

            //SteamClient.Shutdown();
        }
    }
}
