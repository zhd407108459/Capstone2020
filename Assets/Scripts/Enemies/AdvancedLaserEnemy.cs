﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLaserEnemy : BasicEnemy
{
    public GameObject laser1Object;
    public BoxCollider2D laser1Collider;
    public GameObject laser2Object;
    public BoxCollider2D laser2Collider;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();

    private bool isLaserOne;

    void Start()
    {
        laser1Object.SetActive(false);
        laser2Object.SetActive(false);
    }

    void Update()
    {

    }

    public override void Activate()
    {
        base.Activate();
        laser1Object.SetActive(false);
        laser2Object.SetActive(false);
        isLaserOne = true;
    }
    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        if ((shootBeats[beatIndex] && !isRaged) || (ragedShootBeats[beatIndex] && isRaged))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Collider2D[] cos = new Collider2D[0];
        if (isLaserOne)
        {
            laser1Object.SetActive(true);
            cos = Physics2D.OverlapBoxAll(laser1Collider.transform.position, new Vector2(laser1Collider.size.x * laser1Collider.transform.localScale.x, laser1Collider.size.y * laser1Collider.transform.localScale.y), laser1Collider.transform.rotation.eulerAngles.z);
            isLaserOne = false;
        }
        else
        {
            laser2Object.SetActive(true);
            cos = Physics2D.OverlapBoxAll(laser2Collider.transform.position, new Vector2(laser2Collider.size.x * laser2Collider.transform.localScale.x, laser2Collider.size.y * laser2Collider.transform.localScale.y), laser2Collider.transform.rotation.eulerAngles.z);
            isLaserOne = true;
        }
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Player"))
            {
                cos[i].GetComponent<PlayerHealth>().TakeDamage((int)(damage * damageIncreasement));
                Invoke("HideLaserObject", 0.3f);
                return;
            }
        }
        Invoke("HideLaserObject", 0.3f);
    }

    void HideLaserObject()
    {
        laser1Object.SetActive(false);
        laser2Object.SetActive(false);
    }
}
