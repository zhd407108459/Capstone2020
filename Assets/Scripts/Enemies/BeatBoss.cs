using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoss : MonoBehaviour
{

    public int bulletDamage;
    public GameObject bulletPrefab;

    [HideInInspector]public bool isActivated;
    
    void Start()
    {
        isActivated = false;
    }

    
    void Update()
    {
        
    }


    public void OnBeat(int index)
    {
        if (!isActivated)
        {
            return;
        }
        if(index >= BeatsManager.instance.bossSongInfo.beatsInfo.Count)
        {
            return;
        }
        BeatInfo bi = BeatsManager.instance.bossSongInfo.beatsInfo[index];
        for(int i = 0; i < bi.actions.Count; i++)
        {
            if(bi.actions[i].actionType == 1)
            {
                for(int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(-1 * GridManager.instance.gridSize.x, bi.actions[i].actionParameters[j] * GridManager.instance.gridSize.y), transform.rotation);
                    go.GetComponent<EnemyGridBullet>().xDirection = 1;
                    go.GetComponent<EnemyGridBullet>().yDirection = 0;
                    go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
                    go.GetComponent<EnemyGridBullet>().SetUp(0, bi.actions[i].actionParameters[j]);
                }
            }
            if (bi.actions[i].actionType == 2)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(10 * GridManager.instance.gridSize.x, bi.actions[i].actionParameters[j] * GridManager.instance.gridSize.y), transform.rotation);
                    go.GetComponent<EnemyGridBullet>().xDirection = -1;
                    go.GetComponent<EnemyGridBullet>().yDirection = 0;
                    go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
                    go.GetComponent<EnemyGridBullet>().SetUp(9, bi.actions[i].actionParameters[j]);
                }
            }
            if (bi.actions[i].actionType == 3)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(bi.actions[i].actionParameters[j] * GridManager.instance.gridSize.x, 5 * GridManager.instance.gridSize.y), transform.rotation);
                    go.GetComponent<EnemyGridBullet>().xDirection = 0;
                    go.GetComponent<EnemyGridBullet>().yDirection = -1;
                    go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
                    go.GetComponent<EnemyGridBullet>().SetUp(bi.actions[i].actionParameters[j], 4);
                }
            }
            if (bi.actions[i].actionType == 4)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(bi.actions[i].actionParameters[j] * GridManager.instance.gridSize.x, -1 * GridManager.instance.gridSize.y), transform.rotation);
                    go.GetComponent<EnemyGridBullet>().xDirection = 0;
                    go.GetComponent<EnemyGridBullet>().yDirection = 1;
                    go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
                    go.GetComponent<EnemyGridBullet>().SetUp(bi.actions[i].actionParameters[j], 0);
                }
            }

        }
    }
}
