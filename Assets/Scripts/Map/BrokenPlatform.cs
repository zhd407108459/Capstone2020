﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : BasicPlatform
{
    public int brokenTime;
    public int recoverTime;

    public GameObject brokenParticlePrefab;
    public GameObject breakingParticle;

    public Color normalColor;
    public Color breakingColor;
    public Color brokenColor;

    public bool isBreaking;
    public bool isBroken;

    private int breakTimer;

    void Start()
    {
        breakingParticle.SetActive(true);
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

        if (breakingParticle != null)
        {
            ParticleSystem[] ps = breakingParticle.GetComponentsInChildren<ParticleSystem>();
            foreach (var n in ps)
            {
                n.Stop();
            }
        }
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].color = normalColor;
        }
        breakTimer = 0;
    }

    public void Breaking()
    {
        isBreaking = true;
        if(breakingParticle != null)
        {
            ParticleSystem[] ps = breakingParticle.GetComponentsInChildren<ParticleSystem>();
            foreach(var n in ps)
            {
                n.Play();
            }
        }
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
        if (breakingParticle != null)
        {
            ParticleSystem[] ps = breakingParticle.GetComponentsInChildren<ParticleSystem>();
            foreach (var n in ps)
            {
                n.Stop();
            }
        }
        if (brokenParticlePrefab != null)
        {
            Instantiate(brokenParticlePrefab, sprites[0].transform.position, Quaternion.identity);
        }
        GameManager.instance.player.GetComponent<PlayerGridMovement>().CheckYPosition();
    }
}
