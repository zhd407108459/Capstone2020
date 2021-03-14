using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : BasicPlatform
{
    public int brokenTime;
    public int recoverTime;

    public Color normalColor;
    public Color breakingColor;
    public Color brokenColor;

    public bool isBreaking;
    public bool isBroken;

    private int breakTimer;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isBroken)
        {
            if (GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos == xPos && GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos == yPos && GameManager.instance.player.GetComponent<PlayerGridMovement>().IsPlayerInActualPosition())
            {
                Breaking();
            }
            else
            {
                Recover();
            }
        }
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);
        if (isBreaking && !isBroken)
        {
            breakTimer++;
            if (breakTimer > brokenTime)
            {
                Break();
            }
        }
        if (isBroken)
        {
            breakTimer++;
            if (breakTimer > recoverTime)
            {
                Recover();
            }
        }
    }

    public void Recover()
    {
        isBroken = false;
        isBreaking = false;
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].color = normalColor;
        }
        breakTimer = 0;
    }

    public void Breaking()
    {
        isBreaking = true;
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].color = breakingColor;
        }
    }

    public void Break()
    {
        isBroken = true;
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].color = brokenColor;
        }
        breakTimer = 0;
        GameManager.instance.player.GetComponent<PlayerGridMovement>().CheckYPosition();
    }
}
