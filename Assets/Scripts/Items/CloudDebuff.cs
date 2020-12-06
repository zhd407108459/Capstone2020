using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class CloudDebuff : BasicDebuff
{
    public int effectTime;

    public string itemEffectFXEventPath = "event:/FX/Item/FX-Blind";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    

    public override void OnBeat(int beatIndex)
    {
        if(existingTimer > 0)
        {
            existingTimer--;
            if(existingTimer == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            EventInstance itemEffectFX;
            itemEffectFX = RuntimeManager.CreateInstance(itemEffectFXEventPath);
            itemEffectFX.start();
            GameManager.instance.player.GetComponent<PlayerAction>().StartCloud(effectTime);
            Destroy(this.gameObject);
        }
    }
}
