using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Steamworks;
using Steamworks.Data;

public class SpikeTrap : BasicTrap
{
    public int damage;

    public string itemEffectFXEventPath = "event:/FX/Item/FX-Dizzy";

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
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

            CheckGetAllDebuffTrapAchievement();
            GameManager.instance.player.GetComponent<PlayerHealth>().TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }

    private void CheckGetAllDebuffTrapAchievement()
    {
        if (!SteamClient.IsValid)
        {
            try
            {
                SteamClient.Init(1840150);
            }
            catch (System.Exception e)
            {
                // Couldn't init for some reason (steam is closed etc)
                Debug.LogError("Failed to init Steam!");
            }
        }

        if (SteamClient.IsValid)
        {
            var ach = new Achievement("GET_ALL_DEBUFF_TRAP");
            if (!ach.State)
            {
                int fspike = SteamUserStats.GetStatInt("IS_UNLOCK_SPIKE_TRAP");

                if (fspike == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_SPIKE_TRAP", 1);
                }

                int fchaos = SteamUserStats.GetStatInt("IS_UNLOCK_CHAOS_DEBUFF");
                int fcloud = SteamUserStats.GetStatInt("IS_UNLOCK_CLOUD_DEBUFF");
                int fofftune = SteamUserStats.GetStatInt("IS_UNLOCK_OFFTUNE_DEBUFF");
                int fsilence = SteamUserStats.GetStatInt("IS_UNLOCK_SILENCE_DEBUFF");
                int fdizzy = SteamUserStats.GetStatInt("IS_UNLOCK_DIZZY_TRAP");
                fspike = SteamUserStats.GetStatInt("IS_UNLOCK_SPIKE_TRAP");

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
