using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicBulletEnemy : BasicEnemy
{
    //public int shootInterval;
    public GameObject bulletPrefab;

    public GameObject deathRattlePrefab;
    public GameObject deathRattleBuffIconPrefab;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();
    public int xShootDirection;
    public int yShootDirection;

    //public bool isRandom;

    //private int attackTimer;

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
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
        go.GetComponent<EnemyGridBullet>().xDirection = xShootDirection;
        go.GetComponent<EnemyGridBullet>().yDirection = yShootDirection;
        go.GetComponent<EnemyGridBullet>().damage = (int)(damage * damageIncreasement);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos + xShootDirection, yPos + yShootDirection);
    }

    public override void Die()
    {
        base.Die();
        BasicEnemy targetEnemy = GridManager.instance.GetRandomEnemy();
        if (targetEnemy != null)
        {
            GameObject go = Instantiate(deathRattlePrefab, transform.position, transform.rotation);
            UnityEvent events = new UnityEvent();
            events.AddListener(delegate { Deathrattle(targetEnemy); });
            go.GetComponent<EnemyDeathBuffParticle>().SetUp(events, targetEnemy, deathRattleBuffIconPrefab);
        }
    }

    public void Deathrattle(BasicEnemy targetEnemy)
    {
        targetEnemy.damageIncreasement = 1.5f;
    }
}
