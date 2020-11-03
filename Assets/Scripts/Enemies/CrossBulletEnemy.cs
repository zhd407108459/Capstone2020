using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBulletEnemy : BasicEnemy
{
    public GameObject bulletPrefab;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();

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
