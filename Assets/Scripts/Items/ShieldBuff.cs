using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Steamworks;
using Steamworks.Data;

public class ShieldBuff : BasicBuff
{
    public int effectTime;

    public GameObject buffTriggerEffectPrefab;
    public string itemEffectFXEventPath = "event:/FX/Item/FX-PowBoost";

    void Start()
    {

    }

    public override void OnBeat(int beatIndex)
    {
        if (existingTimer > 0)
        {
            existingTimer--;
            if (existingTimer == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if(itemEffectFXEventPath != null && itemEffectFXEventPath != "")
            {
                EventInstance itemEffectFX;
                itemEffectFX = RuntimeManager.CreateInstance(itemEffectFXEventPath);
                if (SettingManager.instance != null)
                {
                    itemEffectFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                }
                itemEffectFX.start();
            }
            GameManager.instance.player.GetComponent<PlayerAction>().StartShield(effectTime);

            if (buffTriggerEffectPrefab != null)
            {
                Instantiate(buffTriggerEffectPrefab, GameManager.instance.player.transform.position, Quaternion.identity);
            }

            CheckGetAllBuffAchievement();
            Destroy(this.gameObject);
        }
    }

    private void CheckGetAllBuffAchievement()
    {
        //try
        //{
        //    SteamClient.Init(1840150);
        //}
        //catch (System.Exception e)
        //{
        //    // Couldn't init for some reason (steam is closed etc)
        //    Debug.LogError("Failed to init Steam!");
        //}

        if (SteamClient.IsValid)
        {
            var ach = new Achievement("GET_ALL_BUFF");
            if (!ach.State)
            {
                int fshield = SteamUserStats.GetStatInt("IS_UNLOCK_SHIELD_BUFF");

                if (fshield == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_SHIELD_BUFF", 1);
                }

                int fhealing = SteamUserStats.GetStatInt("IS_UNLOCK_HEALING_BUFF");
                int fdamage = SteamUserStats.GetStatInt("IS_UNLOCK_DAMAGE_BUFF");
                int fcharging = SteamUserStats.GetStatInt("IS_UNLOCK_CHARGING_BUFF");
                fshield = SteamUserStats.GetStatInt("IS_UNLOCK_SHIELD_BUFF");

                int prog = fhealing + fdamage + fcharging + fshield;

                if (prog == 4)
                {
                    ach.Trigger();
                }

            }

            //SteamClient.Shutdown();
        }
    }
}
