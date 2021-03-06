using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ShellBulletEnemy : BasicEnemy
{
    //public int shootInterval;
    public GameObject bulletPrefab;

    public int shootDelay = 1;
    public int shootInterval;
    public int ragedShootInterval;
    public int detectionRange;

    public string enemyBulletAttackFXEventPath = "event:/FX/Enemy/FX-EnemyLaughter";

    private int state; //0=idle,1=ready to atttack
    private int shootTimer;
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
        shootTimer = -shootDelay;
    }

    public override void OnRestart()
    {
        animator.SetBool("IsOut", false);
    }

    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        shootTimer++;
        if (state == 0)
        {
            if(GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos == yPos && Mathf.Abs(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos - xPos) <= detectionRange)
            {
                state = 1;
                //sprite.GetComponent<SpriteRenderer>().color = Color.red;
                animator.SetBool("IsOut", true);
                if ((shootTimer >= shootInterval && !isRaged) || (shootTimer >= ragedShootInterval && isRaged))
                {
                    shootTimer = isRaged ? ragedShootInterval - 2 : shootInterval - 2;
                }
            }
        }
        if(state == 1)
        {
            if(GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos != yPos || Mathf.Abs(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos - xPos) > detectionRange)
            {
                state = 0;
                //sprite.GetComponent<SpriteRenderer>().color = Color.white;
                animator.SetBool("IsOut", false);
            }
            if(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos - xPos > 0)
            {
                sprite.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                sprite.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((shootTimer >= shootInterval && !isRaged) || (shootTimer >= ragedShootInterval && isRaged))
            {
                shootTimer = 0;
                Shoot();
            }
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
        go.GetComponent<EnemyGridBullet>().xDirection = GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos - xPos > 0 ? 1 : -1;
        go.GetComponent<EnemyGridBullet>().yDirection = 0;
        go.GetComponent<EnemyGridBullet>().damage = (int)(damage * damageIncreasement);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos + (GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos - xPos > 0 ? 1 : -1), yPos);

        animator.SetTrigger("Attack");
    }

    public override void TakeDamage(int damage)
    {
        if(state == 1)
        {
            base.TakeDamage(damage);
        }
    }

}
