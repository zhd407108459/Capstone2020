using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ChaosDebuff : BasicDebuff
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
                    itemEffectFX.setVolume(SettingManager.instance.overAllVolume);
                }
                itemEffectFX.start();
            }
            GameManager.instance.player.GetComponent<PlayerAction>().StartChaos(effectTime);

            if (buffTriggerEffectPrefab != null)
            {
                Instantiate(buffTriggerEffectPrefab, GameManager.instance.player.transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}

