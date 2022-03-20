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
        if (GetComponent<PlayerAction>().isCaught)
        {
            return;
        }
        if(damage > 0 && GetComponent<PlayerAction>().IsShield())
        {
            GetComponent<PlayerAction>().EndShield();
            return;
        }
        if(GetComponent<PlayerAction>().isCaught && 
            (transform.position.x < GridManager.instance.GetPhaseInitialPosition().x - 0.5f * GridManager.instance.gridSize.x || transform.position.x > GridManager.instance.GetPhaseInitialPosition().x + 9.5f * GridManager.instance.gridSize.x ||
            transform.position.y < GridManager.instance.GetPhaseInitialPosition().y - 0.5f * GridManager.instance.gridSize.y || transform.position.y > GridManager.instance.GetPhaseInitialPosition().y + 4.5f * GridManager.instance.gridSize.y))
        {
            return;
        }

        EventInstance damagedFX;
        damagedFX = RuntimeManager.CreateInstance(damagedFXEventPath);
        if (SettingManager.instance != null)
        {
            damagedFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
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
        if(TutorialManager.instance != null)
        {
            return;
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
        if(!GetComponent<PlayerAction>().isDizzy && !GetComponent<PlayerAction>().IsCloud() && !GetComponent<PlayerAction>().IsChaos() && !GetComponent<PlayerAction>().IsOffTune() && !GetComponent<PlayerAction>().IsSilence() && !GetComponent<PlayerAction>().isCaught)
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

    public bool IsAllHealth()
    {
        if(health == maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDead()
    {
        if(health == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
