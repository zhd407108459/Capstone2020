using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BasicBulletEnemy : BasicEnemy
{
    //public int shootInterval;
    public GameObject bulletPrefab;


    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();
    public int xShootDirection;
    public int yShootDirection;

    public string enemyBulletAttackFXEventPath = "event:/FX/Enemy/FX-EnemyBullet";
    //public bool isRandom;

    //private int attackTimer;
    private float timer;
    private float lastTimer;

    void Start()
    {
        //attackTimer = 0;
    }

    void Update()
    {
        
    }


    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        //if (isRandom)
        //{
        //    attackTimer++;
        //    if (attackTimer >= shootInterval)
        //    {
        //        Shoot();
        //        attackTimer = 0;
        //        shootInterval = Random.Range(2, 6);
        //    }
        //}
        /*else */if(/*!isRandom && */(shootBeats[beatIndex] && !isRaged) || (ragedShootBeats[beatIndex] && isRaged))
        {
            animator.SetTrigger("Attack");
            Shoot();
        }
    }

    public void Shoot()
    {
        EventInstance enemyBulletAttackFX;
        enemyBulletAttackFX = RuntimeManager.CreateInstance(enemyBulletAttackFXEventPath);
        if (SettingManager.instance != null)
        {
            float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            enemyBulletAttackFX.setVolume(SettingManager.instance.overAllVolume * (1.0f - value));
        }
        enemyBulletAttackFX.start();

        GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
        go.GetComponent<EnemyGridBullet>().xDirection = xShootDirection;
        go.GetComponent<EnemyGridBullet>().yDirection = yShootDirection;
        go.GetComponent<EnemyGridBullet>().damage = (int)(damage * damageIncreasement);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos + xShootDirection, yPos + yShootDirection);
    }

    
}
