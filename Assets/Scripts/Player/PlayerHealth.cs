using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public Slider healthSlider;

    [HideInInspector] public int health;

    void Start()
    {
        health = maxHealth;
        healthSlider.value = (float)health / (float)maxHealth;
    }

    void Update()
    {

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
        if((float)health / (float)maxHealth < 0.25f){
            BeatsManager.instance.SetNormalBGMParameter("LowHealth", 1);
        }
    }

    public void Die()
    {
        GetComponent<PlayerAction>().ClearAllBuffs();
        GameManager.instance.PlayerDie();
    }

    public void Recover(int value)
    {
        health += value;
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
        healthSlider.value = (float)health / (float)maxHealth;
        if ((float)health / (float)maxHealth >= 0.25f)
        {
            BeatsManager.instance.SetNormalBGMParameter("LowHealth", 0);
        }
    }

    public void RecoverAll()
    {
        health = maxHealth;
        healthSlider.value = (float)health / (float)maxHealth;
        BeatsManager.instance.SetNormalBGMParameter("LowHealth", 0);
    }
}
