using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BrokenPlatform : BasicPlatform
{
    public int brokenTime;
    public int recoverTime;

    public GameObject brokenParticlePrefab;
    public GameObject breakingParticlePrefab;

    public Color normalColor;
    public Color breakingColor;
    public Color brokenColor;

    public bool isBreaking;
    public bool isBroken;

    public string brokenEffectFXEventPath = "event:/FX/Player/FX-GlassBreak";

    private int breakTimer;
    private GameObject breakingParticle;

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
        if (breakingParticle != null)
        {
            ParticleSystem[] ps = breakingParticle.GetComponentsInChildren<ParticleSystem>();
            foreach (var n in ps)
            {
                if (n.isPlaying)
                {
                    n.Stop();
                }
            }
            Destroy(breakingParticle, 3.0f);
            breakingParticle = null;
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
        if (breakingParticlePrefab != null && breakingParticle == null)
        {
            breakingParticle = Instantiate(breakingParticlePrefab, transform.position, Quaternion.identity);
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
                if (n.isPlaying)
                {
                    n.Stop();
                }
            }
            Destroy(breakingParticle, 3.0f);
            breakingParticle = null;
        }
        if (brokenParticlePrefab != null)
        {
            Instantiate(brokenParticlePrefab, transform.position, Quaternion.identity);
        }
        GameManager.instance.player.GetComponent<PlayerGridMovement>().CheckYPosition();

        if(brokenEffectFXEventPath != null && brokenEffectFXEventPath != "")
            {
            EventInstance brokenEffectFX;
            brokenEffectFX = RuntimeManager.CreateInstance(brokenEffectFXEventPath);
            if (SettingManager.instance != null)
            {
                brokenEffectFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            brokenEffectFX.start();
        }
    }
}
