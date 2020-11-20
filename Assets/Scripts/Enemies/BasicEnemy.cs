using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : RhythmObject
{
    public bool isActivated;

    public int maxHealth;
    public Slider healthSlider;

    public Slider extraHealthSlider;

    public int damage;
    public float damageIncreasement;

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
    }
}
