using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : RhythmObject
{
    public bool isActivated;

    public int maxHealth;
    public Slider healthSlider;

    public int xPos;
    public int yPos;

    [HideInInspector] public int health;

    [HideInInspector] public bool isMeleeAttacked;

    [HideInInspector] public bool isRaged;

    public void Activate()
    {
        isActivated = true;
        isRaged = false;
        health = maxHealth;
        healthSlider.value = (float)health / (float)maxHealth;
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
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = (float)health / (float)maxHealth;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
        if (GridManager.instance.IsEnemyClear())
        {
            GridManager.instance.ShowNextStageIcon();
        }
    }
}
