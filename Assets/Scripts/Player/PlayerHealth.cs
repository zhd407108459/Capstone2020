using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public Slider healthSlider;

    public GameObject damageEffectPrefab;

    [HideInInspector] public int health;

    public string damagedFXEventPath = "event:/FX/Player/FX-Damaged";

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
        if (GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
        {
            return;
        }

        EventInstance damagedFX;
        damagedFX = RuntimeManager.CreateInstance(damagedFXEventPath);
        if (SettingManager.instance != null)
        {
            damagedFX.setVolume(SettingManager.instance.overAllVolume);
        }
        damagedFX.start();
        GetComponent<PlayerGridMovement>().animator.SetTrigger("Hurt");

        if(damageEffectPrefab != null)
        {
            Instantiate(damageEffectPrefab, transform.position, transform.rotation);
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
