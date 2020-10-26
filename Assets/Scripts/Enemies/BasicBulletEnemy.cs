using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEnemy : BasicEnemy
{
    //public int shootInterval;
    public GameObject bulletPrefab;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();
    public int xShootDirection;
    public int yShootDirection;
    public int damage;

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
        go.GetComponent<EnemyGridBullet>().damage = damage;
        go.GetComponent<EnemyGridBullet>().SetUp(xPos + xShootDirection, yPos + yShootDirection);
    }
}
