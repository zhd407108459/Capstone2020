using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ReflectionBulletEnemy : BasicEnemy
{
    //public int shootInterval;
    public GameObject bulletPrefab;

    public int startDelay;
    public int shootInterval;
    public int ragedShootInterval;
    public int xShootDirection;
    public int yShootDirection;

    public string enemyBulletAttackFXEventPath = "event:/FX/Enemy/FX-EnemyBoomerang";

    private int shootTimer;
    private bool isLoaded;
    private bool isSpawn;
    //public bool isRandom;

    //private int attackTimer;

    void Start()
    {
        //attackTimer = 0;
    }

    void Update()
    {

    }

    public override void Activate()
    {
        base.Activate();
        isLoaded = true;
        shootTimer = shootInterval - startDelay - 1;
        animator.SetBool("IsAttacked", false);
        if (xShootDirection > 0)
        {
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public override void OnRestart()
    {
        animator.SetBool("IsAttacked", false);
    }

    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        if (isLoaded)
        {
            shootTimer++;
            if ((shootTimer >= shootInterval && !isRaged) || (shootTimer >= ragedShootInterval && isRaged))
            {
                shootTimer = 0;
                Shoot();
            }
        }

    }

    public void Reload(bool isSpawn)
    {
        isLoaded = true;
        shootTimer = 0;
        if (isSpawn)
        {
            animator.SetBool("IsSpawnBullet", true);
            isSpawn = false;
        }
        animator.SetBool("IsAttacked", false);
        this.isSpawn = isSpawn;
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
        go.GetComponent<EnemyReflectionBullet>().xDirection = xShootDirection;
        go.GetComponent<EnemyReflectionBullet>().yDirection = yShootDirection;
        go.GetComponent<EnemyReflectionBullet>().originalXPos = xPos;
        go.GetComponent<EnemyReflectionBullet>().originalYPos = yPos;
        go.GetComponent<EnemyReflectionBullet>().owner = this;
        go.GetComponent<EnemyReflectionBullet>().damage = (int)(damage * damageIncreasement);
        go.GetComponent<EnemyReflectionBullet>().SetUp(xPos + xShootDirection, yPos + yShootDirection);
        animator.SetBool("IsAttacked", true);
        animator.SetBool("IsSpawnBullet", false);
        isLoaded = false;
    }


}
