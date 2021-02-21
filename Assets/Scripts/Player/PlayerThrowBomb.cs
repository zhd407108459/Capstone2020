﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerThrowBomb : RhythmObject
{
    public int damage;
    public int delay;
    public float actionTolerance;
    public KeyCode triggerKey;
    public AbilityIcon abilityIcon;
    public GameObject bombPrefab;
    
    public string throwBombFXEventPath = "event:/FX/Player/FX-Shield";

    private PlayerAction action;
    private int usedBeat;

    void Start()
    {
        action = GetComponent<PlayerAction>();
        usedBeat = -1;
    }

    void Update()
    {
        if (abilityIcon != null && Input.GetKeyDown(triggerKey))
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && abilityIcon.isCoolDown)
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
            throwBombFX.setVolume(SettingManager.instance.overAllVolume);
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
    public void ClearAvalibility()
    {
        if (abilityIcon != null)
        {
            abilityIcon.HideIcons();
        }
        abilityIcon = null;
    }
}
