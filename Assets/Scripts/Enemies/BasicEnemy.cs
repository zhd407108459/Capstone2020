using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
    public SpriteRenderer sprite;

    [HideInInspector] public int health;

    [HideInInspector] public bool isMeleeAttacked;

    [HideInInspector] public bool isRaged;

    [HideInInspector] public int extraHealth;
    [HideInInspector] public int maxExtraHealth;


    void Start()
    {
        extraHealthSlider.gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        isActivated = true;
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

    public void TakeDamage(int damage)
    {
        Camera.main.GetComponent<CameraShake>().Shake();
        int tempD = damage;
        if(extraHealth > 0)
        {
            if(extraHealth > tempD)
            {
                extraHealth -= tempD;
                extraHealthSlider.value = (float)extraHealth / (float)maxExtraHealth;
                return;
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
            Die();
        }
        healthSlider.value = (float)health / (float)maxHealth;
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
        this.gameObject.SetActive(false);
        if (GridManager.instance.IsEnemyClear())
        {
            GridManager.instance.ShowNextStageIcon();
        }
        if(dealthRattleType > 0 && dealthRattleType < 5)
        {
            BasicEnemy targetEnemy = GridManager.instance.GetRandomEnemy();
            if (targetEnemy != null)
            {
                GameObject go = Instantiate(deathRattlePrefab, transform.position, transform.rotation);
                UnityEvent events = new UnityEvent();
                if(dealthRattleType == 1)
                {
                    events.AddListener(delegate { DeathRattleExtraHealth(targetEnemy); });
                }
                else if (dealthRattleType == 2)
                {
                    events.AddListener(delegate { DeathRattleHealing(targetEnemy); });
                }
                else if (dealthRattleType == 3)
                {
                    events.AddListener(delegate { DeathRattlePowerUp(targetEnemy); });
                }
                else if (dealthRattleType == 4)
                {
                    events.AddListener(delegate { DeathRattleRage(targetEnemy); });
                }
                go.GetComponent<EnemyDeathBuffParticle>().SetUp(events, targetEnemy, deathRattleBuffIconPrefab);
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
}
