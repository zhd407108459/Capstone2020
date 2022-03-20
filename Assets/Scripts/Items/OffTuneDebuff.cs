using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Steamworks;
using Steamworks.Data;

public class OffTuneDebuff : BasicDebuff
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
            GameManager.instance.player.GetComponent<PlayerAction>().StartOffTune(effectTime);

            if (buffTriggerEffectPrefab != null)
            {
                Instantiate(buffTriggerEffectPrefab, GameManager.instance.player.transform.position, Quaternion.identity);
            }

            CheckGetAllDebuffTrapAchievement();
            Destroy(this.gameObject);
        }
    }

    private void CheckGetAllDebuffTrapAchievement()
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
            var ach = new Achievement("GET_ALL_DEBUFF_TRAP");
            if (!ach.State)
            {
                int fofftune = SteamUserStats.GetStatInt("IS_UNLOCK_OFFTUNE_DEBUFF");

                if (fofftune == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_OFFTUNE_DEBUFF", 1);
                }

                int fchaos = SteamUserStats.GetStatInt("IS_UNLOCK_CHAOS_DEBUFF");
                int fcloud = SteamUserStats.GetStatInt("IS_UNLOCK_CLOUD_DEBUFF");
                fofftune = SteamUserStats.GetStatInt("IS_UNLOCK_OFFTUNE_DEBUFF");
                int fsilence = SteamUserStats.GetStatInt("IS_UNLOCK_SILENCE_DEBUFF");
                int fdizzy = SteamUserStats.GetStatInt("IS_UNLOCK_DIZZY_TRAP");
                int fspike = SteamUserStats.GetStatInt("IS_UNLOCK_SPIKE_TRAP");

                int prog = fchaos + fcloud + fofftune + fsilence + fdizzy + fspike;

                if (prog == 6)
                {
                    ach.Trigger();
                }

            }

            //SteamClient.Shutdown();
        }
    }
}
