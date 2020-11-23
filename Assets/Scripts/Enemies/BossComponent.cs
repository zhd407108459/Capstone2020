using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComponent : RhythmObject
{
    private int timer;
    private int hideTime;

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
}
