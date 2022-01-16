﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DamageIncreasingBuff : BasicBuff
{
    public float damageIncreasementRatio;
    public int effectTime;

    public GameObject buffTriggerEffectPrefab;

    public string itemEffectFXEventPath = "event:/FX/Item/FX-PowBoost";

    public bool isForTutorial = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void OnBeat(int beatIndex)
    {
        if (existingTimer > 0)
        {
            existingTimer--;
            if (existingTimer == 0)
            {
                if (isForTutorial)
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (itemEffectFXEventPath != null && itemEffectFXEventPath != "")
            {
                EventInstance itemEffectFX;
                itemEffectFX = RuntimeManager.CreateInstance(itemEffectFXEventPath);
                if (SettingManager.instance != null)
                {
                    itemEffectFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                }
                itemEffectFX.start();
            }
            GameManager.instance.player.GetComponent<PlayerAction>().StartIncreasingDamage(effectTime, damageIncreasementRatio);

            if (buffTriggerEffectPrefab != null)
            {
                Instantiate(buffTriggerEffectPrefab, GameManager.instance.player.transform.position, Quaternion.identity);
            }

            if (isForTutorial)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
