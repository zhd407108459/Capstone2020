using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerThrowBomb : RhythmObject
{
    public int basicDamage;
    public int easyDifficultyDamageOffset;
    public int normalDifficultyDamageOffset;
    public int delay;
    public float actionTolerance;
    public KeyCode triggerKey;
    public AbilityIcon abilityIcon;
    public GameObject bombPrefab;
    
    public string throwBombFXEventPath = "event:/FX/Player/FX-Shield";

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
        usedBeat = -1;
    }

    void Update()
    {
        if (abilityIcon != null && Input.GetKeyDown(triggerKey) && !action.IsOffTune())
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && abilityIcon.isCoolDown && !GameManager.instance.isCutScene)
            {
                ThrowBomb();
            }
        }
    }
    public override void OnBeat(int beatIndex)
    {
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

    public void ThrowBomb()
    {
        abilityIcon.StartCoolDown();
        if (BeatsManager.instance.GetTimeToNextBeat() < BeatsManager.instance.GetTimeToLastBeat())
        {
            usedBeat = BeatsManager.instance.GetIndexToNearestBeat();
        }
        EventInstance throwBombFX;
        throwBombFX = RuntimeManager.CreateInstance(throwBombFXEventPath);
        if (SettingManager.instance != null)
        {
            throwBombFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        throwBombFX.start();

        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        bomb.GetComponent<PlayerBomb>().SetUp(delay, damage, GetComponent<PlayerGridMovement>().xPos, GetComponent<PlayerGridMovement>().yPos);

        action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        GridManager.instance.AddCombo();
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
        if (abilityIcon != null)
        {
            abilityIcon.HideIcons();
        }
        abilityIcon = null;
    }
}
