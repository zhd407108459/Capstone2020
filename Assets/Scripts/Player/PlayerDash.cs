﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerDash : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public int basicDamage;
    public int easyDifficultyDamageOffset;
    public int normalDifficultyDamageOffset;
    public GameObject dashEffectPrefab;
    public GameObject hitEffectPrefab;
    public KeyCode triggerKey;
    public AbilityIcon abilityIcon;
    [HideInInspector] public bool isDashing;
    [HideInInspector] public int damage;

    public string dashFXEventPath = "event:/FX/Player/FX-Dash";

    private int usedBeat;

    void Start()
    {
        damage = basicDamage;
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.difficulty == 1)
            {
                damage += normalDifficultyDamageOffset;
            }
            if (SettingManager.instance.difficulty == 0)
            {
                damage += easyDifficultyDamageOffset;
            }
        }
        isDashing = false;
        //ChangeBeatTips();
        usedBeat = -1;
    }

    void ChangeBeatTips()
    {
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowDashIcon();
            }
        }
    }
    public void SetSingleAvalibility(int n)
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
        availability[n] = true;
    }

    public void SetAbilityIcon(AbilityIcon icon)
    {
        abilityIcon = icon;
        triggerKey = icon.triggerKey;
        abilityIcon.coolDownTimer = 3;
    }

    public void SetAbilityKey()
    {
        if (abilityIcon != null)
        {
            triggerKey = abilityIcon.triggerKey;
        }
    }

    public void ClearAvalibility()
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
        if (abilityIcon != null)
        {
            abilityIcon.HideIcons();
        }
        abilityIcon = null;
    }

    public override void OnBeat(int beatIndex)
    {
        if (GridManager.instance.isInPhase && abilityIcon != null)
        {
            if(beatIndex == usedBeat)
            {
                usedBeat = -1;
            }
            else
            {
                if (abilityIcon.coolDownTimer < abilityIcon.abilityCoolDown.Count)
                {
                    abilityIcon.ChargeAbility();
                }
            }
        }
    }

    public override void OnSemiBeat(int lastBeatIndex)
    {
        if (GridManager.instance.isInPhase && abilityIcon != null)
        {
            if (abilityIcon.coolDownTimer == abilityIcon.abilityCoolDown.Count && !abilityIcon.isCoolDown)
            {
                abilityIcon.Charged();
            }
        }
    }

    public void StartDash()
    {
        isDashing = true;
        abilityIcon.StartCoolDown();
        if(BeatsManager.instance.GetTimeToNextBeat() < BeatsManager.instance.GetTimeToLastBeat())
        {
            usedBeat = BeatsManager.instance.GetIndexToNearestBeat();
        }
        EventInstance dashFX;
        dashFX = RuntimeManager.CreateInstance(dashFXEventPath);
        if (SettingManager.instance != null)
        {
            dashFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        dashFX.start();
        Invoke("EndDash", 0.4f);
        if(dashEffectPrefab != null)
        {
            GameObject effect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);
            if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
            {
                effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
            }
        }
        Collider2D[] cos = Physics2D.OverlapBoxAll(transform.position, new Vector2(GetComponent<BoxCollider2D>().size.x * transform.localScale.x, GetComponent<BoxCollider2D>().size.y * transform.localScale.y), transform.rotation.eulerAngles.z);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Enemy"))
            {
                if (!cos[i].GetComponent<BasicEnemy>().isDashed)
                {
                    if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                        GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                    }
                    else
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage(damage);
                    }
                    Camera.main.GetComponent<CameraShake>().Shake();
                    cos[i].GetComponent<BasicEnemy>().Dashed();
                    if (hitEffectPrefab != null)
                    {
                        GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                        if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                        {
                            effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                        }
                    }
                }
            }
            if (cos[i].tag.Equals("BossComponent"))
            {
                if (!cos[i].GetComponent<BossComponent>().isDashed)
                {
                    if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                    {
                        GridManager.instance.boss.TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                        GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                    }
                    else
                    {
                        GridManager.instance.boss.TakeDamage(damage);
                    }
                    Camera.main.GetComponent<CameraShake>().Shake();
                    cos[i].GetComponent<BossComponent>().Dashed();
                    if (hitEffectPrefab != null)
                    {
                        GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                        if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                        {
                            effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                        }
                    }
                }
            }
            if (cos[i].tag.Equals("BossBomb"))
            {
                Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(GridManager.instance.boss.centerShootPosX * GridManager.instance.gridSize.x, GridManager.instance.boss.centerShootPosY * GridManager.instance.gridSize.y);
                if ((cos[i].transform.position.x - centerPos.x >= 0 && !GetComponent<PlayerGridMovement>().isPlayerFacingRight) || (cos[i].transform.position.x - centerPos.x < 0 && GetComponent<PlayerGridMovement>().isPlayerFacingRight))
                {
                    cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(centerPos, true);
                }
                else
                {
                    if (cos[i].transform.position.x - centerPos.x >= 0)
                    {
                        cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(cos[i].transform.position + new Vector3(5.0f, 0, 0), false);
                    }
                    else
                    {
                        cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(cos[i].transform.position + new Vector3(-5.0f, 0, 0), false);
                    }
                }
                Camera.main.GetComponent<CameraShake>().Shake();
                if (hitEffectPrefab != null)
                {
                    GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                    if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                    {
                        effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                    }
                }

            }
        }
    }

    public void EndDash()
    {
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDashing)
        {
            return;
        }
        if (collision.tag.Equals("Enemy"))
        {
            if (!collision.GetComponent<BasicEnemy>().isDashed)
            {
                if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                {
                    collision.GetComponent<BasicEnemy>().TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                    GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                }
                else
                {
                    collision.GetComponent<BasicEnemy>().TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();
                collision.GetComponent<BasicEnemy>().Dashed();
                if (hitEffectPrefab != null)
                {
                    GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                    if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                    {
                        effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                    }
                }
            }
        }
        if (collision.tag.Equals("BossComponent"))
        {
            if (!collision.GetComponent<BossComponent>().isDashed)
            {
                if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                {
                    GridManager.instance.boss.TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                    GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                }
                else
                {
                    GridManager.instance.boss.TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();
                collision.GetComponent<BossComponent>().Dashed();
                if (hitEffectPrefab != null)
                {
                    GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                    if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                    {
                        effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                    }
                }
            }
        }
        if (collision.tag.Equals("BossBomb"))
        {
            Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(GridManager.instance.boss.centerShootPosX * GridManager.instance.gridSize.x, GridManager.instance.boss.centerShootPosY * GridManager.instance.gridSize.y);
            if ((collision.transform.position.x - centerPos.x >= 0 && !GetComponent<PlayerGridMovement>().isPlayerFacingRight) || (collision.transform.position.x - centerPos.x < 0 && GetComponent<PlayerGridMovement>().isPlayerFacingRight))
            {
                collision.GetComponent<EnemyBomb>().AttackedByPlayer(centerPos, true);
            }
            else
            {
                if (collision.transform.position.x - centerPos.x >= 0)
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(5.0f, 0, 0), false);
                }
                else
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(-5.0f, 0, 0), false);
                }
            }
            Camera.main.GetComponent<CameraShake>().Shake();
            if (hitEffectPrefab != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                {
                    effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isDashing)
        {
            return;
        }
        if (collision.tag.Equals("Enemy"))
        {
            if (!collision.GetComponent<BasicEnemy>().isDashed)
            {
                if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                {
                    collision.GetComponent<BasicEnemy>().TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                    GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                }
                else
                {
                    collision.GetComponent<BasicEnemy>().TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();
                collision.GetComponent<BasicEnemy>().Dashed();
                if (hitEffectPrefab != null)
                {
                    GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                    if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                    {
                        effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                    }
                }
            }
        }
        if (collision.tag.Equals("BossComponent"))
        {
            if (!collision.GetComponent<BossComponent>().isDashed)
            {
                if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
                {
                    GridManager.instance.boss.TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                    GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
                }
                else
                {
                    GridManager.instance.boss.TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();
                collision.GetComponent<BossComponent>().Dashed();
                if (hitEffectPrefab != null)
                {
                    GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                    if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                    {
                        effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                    }
                }
            }
        }
        if (collision.tag.Equals("BossBomb"))
        {
            Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(GridManager.instance.boss.centerShootPosX * GridManager.instance.gridSize.x, GridManager.instance.boss.centerShootPosY * GridManager.instance.gridSize.y);
            if ((collision.transform.position.x - centerPos.x >= 0 && !GetComponent<PlayerGridMovement>().isPlayerFacingRight) || (collision.transform.position.x - centerPos.x < 0 && GetComponent<PlayerGridMovement>().isPlayerFacingRight))
            {
                collision.GetComponent<EnemyBomb>().AttackedByPlayer(centerPos, true);
            }
            else
            {
                if (collision.transform.position.x - centerPos.x >= 0)
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(5.0f, 0, 0), false);
                }
                else
                {
                    collision.GetComponent<EnemyBomb>().AttackedByPlayer(collision.transform.position + new Vector3(-5.0f, 0, 0), false);
                }
            }
            Camera.main.GetComponent<CameraShake>().Shake();
            if (hitEffectPrefab != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                {
                    effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                }
            }

        }
    }
}

