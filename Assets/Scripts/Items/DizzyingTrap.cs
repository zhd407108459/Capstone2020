using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DizzyingTrap : BasicTrap
{
    public int effectTime;

    public string itemEffectFXEventPath = "event:/FX/Item/FX-Dizzy";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing) 
        {
            EventInstance itemEffectFX;
            itemEffectFX = RuntimeManager.CreateInstance(itemEffectFXEventPath);
            if (SettingManager.instance != null)
            {
                itemEffectFX.setVolume(SettingManager.instance.overAllVolume);
            }
            itemEffectFX.start();
            GameManager.instance.player.GetComponent<PlayerAction>().StartDizzy(effectTime);
            this.gameObject.SetActive(false);
        }
    }
}
