using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerMeleeAttack : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D meleeAttackBox;
    public int damage;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    public string meleeAttackFXEventPath = "event:/FX/Player/FX-MeleeAttack";
    public string meleeImpactFXEventPath = "event:/FX/Player/FX-MeleeImpact";

    public GameObject meleeAttackEffectPrefab;
    public GameObject hitEffectPrefab;

    private PlayerAction action;

    void Start()
    {
        if(SettingManager.instance != null)
        {
            isAutoUse = SettingManager.instance.isAutoAttack;
        }
        HideMeleeAttackBox();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (!isAutoUse)
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && availability[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused)//!action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()])// 
            {
                if (Input.GetKeyDown(triggerKey))
                {
                    MeleeAttack();
                }
            }
        }
        if (meleeAttackBox.gameObject.activeSelf)
        {
            Attack();
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if(isAutoUse && availability[beatIndex] && GridManager.instance.isInPhase && !action.isDizzy)
        {
            MeleeAttack();
        }
    }

    void ChangeBeatTips()
    {
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowMeleeAttackIcon(); ;
            }
        }
    }
    void MeleeAttack()
    {
        EventInstance meleeAttackFX;
        meleeAttackFX = RuntimeManager.CreateInstance(meleeAttackFXEventPath);
        if (SettingManager.instance != null)
        {
            meleeAttackFX.setVolume(SettingManager.instance.overAllVolume);
        }
        meleeAttackFX.start();

        meleeAttackBox.gameObject.SetActive(true);
        //action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideMeleeAttackBox", existingTime);
        GetComponent<PlayerGridMovement>().animator.SetTrigger("MeleeAttack");

        if(meleeAttackEffectPrefab != null)
        {
            GameObject effect = Instantiate(meleeAttackEffectPrefab, transform.position, transform.rotation);
            if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
            {
                effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
            }
        }
    }

    void Attack()
    {
        Collider2D[] cos = Physics2D.OverlapBoxAll(meleeAttackBox.transform.position, new Vector2(meleeAttackBox.size.x * meleeAttackBox.transform.localScale.x, meleeAttackBox.size.y * meleeAttackBox.transform.localScale.y), meleeAttackBox.transform.rotation.eulerAngles.z);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Enemy"))
            {
                if (!cos[i].GetComponent<BasicEnemy>().isMeleeAttacked)
                {
                    if(action.damageIncreasingRatio > 1)
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage((int)(damage * action.damageIncreasingRatio));
                        cos[i].GetComponent<BasicEnemy>().MeleeAttacked();
                        action.EndIncreasingDamage();
                    }
                    else
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage(damage);
                        cos[i].GetComponent<BasicEnemy>().MeleeAttacked();
                    }
                    Camera.main.GetComponent<CameraShake>().Shake();

                    EventInstance meleeImpactFX;
                    meleeImpactFX = RuntimeManager.CreateInstance(meleeImpactFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume);
                    }
                    meleeImpactFX.start();

                    if(hitEffectPrefab != null)
                    {
                        Instantiate(hitEffectPrefab, cos[i].transform.position, Quaternion.identity);
                    }
                }
            }
            if (cos[i].tag.Equals("BossComponent"))
            {
                if (!GridManager.instance.boss.isMeleeAttacked)
                {
                    if (action.damageIncreasingRatio > 1)
                    {
                        GridManager.instance.boss.TakeDamage((int)(damage * action.damageIncreasingRatio));
                        GridManager.instance.boss.MeleeAttacked();
                        action.EndIncreasingDamage();
                    }
                    else
                    {
                        GridManager.instance.boss.TakeDamage(damage);
                        GridManager.instance.boss.MeleeAttacked();
                    }
                    Camera.main.GetComponent<CameraShake>().Shake();

                    EventInstance meleeImpactFX;
                    meleeImpactFX = RuntimeManager.CreateInstance(meleeImpactFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume);
                    }
                    meleeImpactFX.start();

                    if (hitEffectPrefab != null)
                    {
                        Instantiate(hitEffectPrefab, cos[i].transform.position, Quaternion.identity);
                    }
                }
            }
            if (cos[i].tag.Equals("BossBomb"))
            {
                if (!cos[i].GetComponent<EnemyBomb>().isAttacked)
                {
                    Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(GridManager.instance.boss.centerShootPosX * GridManager.instance.gridSize.x, GridManager.instance.boss.centerShootPosY * GridManager.instance.gridSize.y);
                    //Debug.Log(cos[i].transform.position.x - centerPos.x);
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

                    EventInstance meleeImpactFX;
                    meleeImpactFX = RuntimeManager.CreateInstance(meleeImpactFXEventPath);
                    if (SettingManager.instance != null)
                    {
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume);
                    }
                    meleeImpactFX.start();

                    if (hitEffectPrefab != null)
                    {
                        Instantiate(hitEffectPrefab, cos[i].transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    void HideMeleeAttackBox()
    {
        meleeAttackBox.gameObject.SetActive(false);
    }

    public void SetSingleAvalibility(int n)
    {
        for(int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
        availability[n] = true;
    }

    public void ClearAvalibility()
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
    }
}
