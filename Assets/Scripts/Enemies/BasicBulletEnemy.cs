using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEnemy : BasicEnemy
{
    public int shootInterval;
    public GameObject bulletPrefab;

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
        attackTimer++;
        if (attackTimer >= shootInterval)
        {
            Shoot();
            attackTimer = 0;
            shootInterval = Random.Range(2, 6);
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos, yPos);
    }
}
