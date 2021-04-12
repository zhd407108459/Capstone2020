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
    public int basicDamage;
    public int easyDifficultyDamageOffset;
    public int normalDifficultyDamageOffset;
    public float actionTolerance;
    public KeyCode triggerKey;
    public AbilityIcon abilityIcon;
    public bool isAutoUse;

    public string meleeAttackFXEventPath = "event:/FX/Player/FX-MeleeAttack";
    public string meleeImpactFXEventPath = "event:/FX/Player/FX-MeleeImpact";
    public string meleeHitNoDamageFXEventPath = "event:/FX/Player/FX-HitNoDamage";

    public GameObject meleeAttackEffectPrefab;
    public GameObject hitEffectPrefab;

    [HideInInspector] public int damage;

    private PlayerAction action;
    private int usedBeat;

    private void Awake()
    {
        action = GetComponent<PlayerAction>();
    }

    void Start()
    {
        damage = basicDamage;
        if(SettingManager.instance != null)
        {
            //isAutoUse = SettingManager.instance.isAutoAttack;
            if (SettingManager.instance.difficulty == 1)
            {
                damage += normalDifficultyDamageOffset;
            }
            if (SettingManager.instance.difficulty == 0)
            {
                damage += easyDifficultyDamageOffset;
            }
        }
        HideMeleeAttackBox();
        usedBeat = -1;
        //ChangeBeatTips();
    }

    void Update()
    {
        //if (!isAutoUse)
        //{
        //    if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && availability[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused)//!action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()])// 
        //    {
        //        if (Input.GetKeyDown(triggerKey))
        //        {
        //            MeleeAttack();
        //        }
        //    }
        //}
        if(abilityIcon != null && Input.GetKeyDown(triggerKey) && !action.IsOffTune())
        {
            if(BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && abilityIcon.isCoolDown && !GameManager.instance.isCutScene)
            {
                MeleeAttack();
            }
        }
        if (meleeAttackBox.gameObject.activeSelf)
        {
            Attack();
        }
    }

    public override void OnBeat(int beatIndex)
    {
        //if(isAutoUse && availability[beatIndex] && GridManager.instance.isInPhase && !action.isDizzy)
        //{
        //    MeleeAttack();
        //}
        if (GridManager.instance.isInPhase && abilityIcon != null)
        {
            if (beatIndex == usedBeat)
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
        abilityIcon.StartCoolDown();
        if (BeatsManager.instance.GetTimeToNextBeat() < BeatsManager.instance.GetTimeToLastBeat())
        {
            usedBeat = BeatsManager.instance.GetIndexToNearestBeat();
        }
        EventInstance meleeAttackFX;
        meleeAttackFX = RuntimeManager.CreateInstance(meleeAttackFXEventPath);
        if (SettingManager.instance != null)
        {
            meleeAttackFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        meleeAttackFX.start();

        meleeAttackBox.gameObject.SetActive(true);
        action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideMeleeAttackBox", existingTime);
        GetComponent<PlayerGridMovement>().animator.SetTrigger("MeleeAttack");
        GridManager.instance.AddCombo();

        if (meleeAttackEffectPrefab != null)
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
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
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
                    if (GridManager.instance.boss.canBeAttacked)
                    {
                        meleeImpactFX = RuntimeManager.CreateInstance(meleeImpactFXEventPath);
                    }
                    else
                    {
                        meleeImpactFX = RuntimeManager.CreateInstance(meleeHitNoDamageFXEventPath);
                    }
                    if (SettingManager.instance != null)
                    {
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                    }
                    meleeImpactFX.start();

                    if (hitEffectPrefab != null)
                    {
                        if (cos[i].GetComponent<SolidAttack>() == null)
                        {
                            Instantiate(hitEffectPrefab, cos[i].transform.position, Quaternion.identity);
                        }
                        else
                        {
                            if (cos[i].GetComponent<SolidAttack>().xPos == GetComponent<PlayerGridMovement>().xPos)
                            {
                                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                            }
                            else if (cos[i].GetComponent<SolidAttack>().xPos < GetComponent<PlayerGridMovement>().xPos && GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                            {
                                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                            }
                            else if (cos[i].GetComponent<SolidAttack>().xPos > GetComponent<PlayerGridMovement>().xPos && !GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                            {
                                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                            }
                            else
                            {
                                Instantiate(hitEffectPrefab, transform.position + new Vector3(GridManager.instance.gridSize.x * (GetComponent<PlayerGridMovement>().isPlayerFacingRight ? 1 : -1), 0, 0), Quaternion.identity);
                            }
                        }
                        
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
                        meleeImpactFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
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
}
