using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEnemy : RhythmObject
{
    public int shootInterval;
    public GameObject bulletPrefab;

    public int xPos;
    public int yPos;

    private int attackTimer;

    void Start()
    {
        transform.position = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        attackTimer = 0;
    }

    void Update()
    {

    }

    public override void OnBeat(int beatIndex)
    {
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
