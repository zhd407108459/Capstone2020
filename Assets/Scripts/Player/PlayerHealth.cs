using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    public int basicHealth;
    public int easyDifficultyHealthOffset;
    public int normalDifficultyHealthOffset;
    public Slider healthSlider;

    public GameObject damageEffectPrefab;

    [HideInInspector] public int maxHealth;
    [HideInInspector] public int health;

    public string damagedFXEventPath = "event:/FX/Player/FX-Damaged";

    void Start()
    {
        maxHealth = basicHealth;
        if(SettingManager.instance != null)
        {
            if(SettingManager.instance.difficulty == 1)
            {
                maxHealth += normalDifficultyHealthOffset;
            }
            if(SettingManager.instance.difficulty == 0)
            {
                maxHealth += easyDifficultyHealthOffset;
            }
        }
        health = maxHealth;
        healthSlider.value = (float)health / (float)maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
        {
            return;
        }
        if(damage > 0 && GetComponent<PlayerAction>().IsShield())
        {
            GetComponent<PlayerAction>().EndShield();
            return;
        }

        EventInstance damagedFX;
        damagedFX = RuntimeManager.CreateInstance(damagedFXEventPath);
        if (SettingManager.instance != null)
        {
            damagedFX.setVolume(SettingManager.instance.overAllVolume);
        }
        damagedFX.start();
        GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", true);
        Invoke("EndHurtAnimation", 0.6f);

        if (damageEffectPrefab != null)
        {
            Instantiate(damageEffectPrefab, transform.position, transform.rotation);
        }
        if(damage > 0)
        {
            GridManager.instance.EndCombo();
        }
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

    void EndHurtAnimation()
    {
        if(!GetComponent<PlayerAction>().isDizzy && !GetComponent<PlayerAction>().IsCloud())
        {
            GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", false);
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
