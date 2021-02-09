using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComponent : RhythmObject
{
    private int timer;
    private int hideTime;
    [HideInInspector] public bool isDashed;

    public override void OnBeat(int beatIndex)
    {
        if (this.gameObject.activeSelf)
        {
            timer++;
            if (timer >= hideTime && hideTime > 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Show(int hideTime)
    {
        this.hideTime = hideTime;
        timer = 0;
        this.gameObject.SetActive(true);
    }

    public void Dashed()
    {
        isDashed = true;
        Invoke("TurnOffIsDashed", 0.4f);
    }

    void TurnOffIsDashed()
    {
        isDashed = false;
    }
}
