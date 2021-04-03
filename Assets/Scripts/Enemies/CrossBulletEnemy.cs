using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class CrossBulletEnemy : BasicEnemy
{
    public GameObject bulletPrefab;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();

    public string enemyBulletAttackFXEventPath = "event:/FX/Enemy/FX-EnemyBullet";

    private int attackTimer;

    void Start()
    {
        attackTimer = 0;
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
        if ((shootBeats[beatIndex] && !isRaged) || (ragedShootBeats[beatIndex] && isRaged))
        {
            EventInstance enemyBulletAttackFX;
            enemyBulletAttackFX = RuntimeManager.CreateInstance(enemyBulletAttackFXEventPath);
            if (SettingManager.instance != null)
            {
                float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                enemyBulletAttackFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
            }
            enemyBulletAttackFX.start();

            animator.SetTrigger("Attack");
            Shoot(1, 0);
            Shoot(-1, 0);
            Shoot(0, 1);
            Shoot(0, -1);
        }
    }

    public void Shoot(int xShootDirection, int yShootDirection)
    {
        GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
        go.GetComponent<EnemyGridBullet>().xDirection = xShootDirection;
        go.GetComponent<EnemyGridBullet>().yDirection = yShootDirection;
        go.GetComponent<EnemyGridBullet>().damage = (int)(damage * damageIncreasement);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos + xShootDirection, yPos + yShootDirection);
    }
}
