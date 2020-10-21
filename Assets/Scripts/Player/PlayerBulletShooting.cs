using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooting : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public GameObject bulletPrefab;
    public int damage;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    private PlayerAction action;

    void Start()
    {
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
                    ShootBullet();
                }
            }
        }

    }

    public override void OnBeat(int beatIndex)
    {
        if (isAutoUse && availability[beatIndex] && GridManager.instance.isInPhase && !action.isDizzy)
        {
            ShootBullet();
        }
    }

    void ChangeBeatTips()
    {
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon(); ;
            }
        }
    }

    void ShootBullet()
    {
        GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
        if (GetComponent<PlayerGridMovement>().isPlayerFacingRight)
        {
            go.GetComponent<PlayerGridBullet>().xDirection = 1;
        }
        else
        {
            go.GetComponent<PlayerGridBullet>().xDirection = -1;
        }
        go.GetComponent<PlayerGridBullet>().yDirection = 0;
        go.GetComponent<PlayerGridBullet>().damage = damage;
        go.GetComponent<PlayerGridBullet>().SetUp(GetComponent<PlayerGridMovement>().xPos, GetComponent<PlayerGridMovement>().yPos);
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
