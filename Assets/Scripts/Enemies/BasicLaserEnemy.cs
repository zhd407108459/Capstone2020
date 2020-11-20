﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLaserEnemy : BasicEnemy
{
    public GameObject laserObject;
    public BoxCollider2D laserCollider;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();

    void Start()
    {
        laserObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public override void Activate()
    {
        base.Activate();
        laserObject.SetActive(false);
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
        laserObject.SetActive(true);
        Collider2D[] cos = Physics2D.OverlapBoxAll(laserCollider.transform.position, new Vector2(laserCollider.size.x * laserCollider.transform.localScale.x, laserCollider.size.y * laserCollider.transform.localScale.y), laserCollider.transform.rotation.eulerAngles.z);
        for(int i = 0; i < cos.Length; i++)
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
        laserObject.SetActive(false);
    }
}
