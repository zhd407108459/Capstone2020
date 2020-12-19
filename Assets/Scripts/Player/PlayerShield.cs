using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerShield : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D shieldBox;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    public string shieldFXEventPath = "event:/FX/Player/FX-Shield";

    private PlayerAction action;

    void Start()
    {
        if (SettingManager.instance != null)
        {
            isAutoUse = SettingManager.instance.isAutoAttack;
        }
        HideShield();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (!isAutoUse)
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && availability[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused)//!action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()])// 
            {
                if (Input.GetKeyDown(triggerKey))
                {
                    UseShield();
                }
            }
        }
            
    }

    public override void OnBeat(int beatIndex)
    {
        if (isAutoUse && availability[beatIndex] && GridManager.instance.isInPhase && !action.isDizzy)
        {
            UseShield();
        }
    }

    void ChangeBeatTips()
    {
        for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon(); 
            }
        }
    }

    void UseShield()
    {
        EventInstance shieldFX;
        shieldFX = RuntimeManager.CreateInstance(shieldFXEventPath);
        if (SettingManager.instance != null)
        {
            shieldFX.setVolume(SettingManager.instance.overAllVolume);
        }
        shieldFX.start();

        shieldBox.gameObject.SetActive(true);
        //Collider2D[] cos = Physics2D.OverlapBoxAll(shieldBox.transform.position, new Vector2(shieldBox.size.x * shieldBox.transform.localScale.x, shieldBox.size.y * shieldBox.transform.localScale.y), shieldBox.transform.rotation.eulerAngles.z);
        //for (int i = 0; i < cos.Length; i++)
        //{
        //    if (cos[i].tag.Equals("EnemyBullet"))
        //    {
        //        Destroy(cos[i].gameObject);
        //        Camera.main.GetComponent<CameraShake>().Shake();
        //    }
        //}
        //action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideShield", existingTime);
    }

    void HideShield()
    {
        shieldBox.gameObject.SetActive(false);
    }

    public void SetSingleAvalibility(int n)
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
        availability[n] = true;
    }
    public void ClearAvalibility()
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
    }
}
