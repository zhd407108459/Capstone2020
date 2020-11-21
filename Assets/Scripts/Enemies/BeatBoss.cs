using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoss : MonoBehaviour
{

    public int bulletDamage;
    public GameObject bulletPrefab;

    public int solidDamage;
    public GameObject solidPrefab;
    public int solidAttackDelay;
    public int solidStayDelay;

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
            //Bullet attack
            if(bi.actions[i].actionType == 1)
            {
                for(int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossBulletAttack(1, 0, 0, bi.actions[i].actionParameters[j]);
                }
            }
            if (bi.actions[i].actionType == 2)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossBulletAttack(-1, 0, 9, bi.actions[i].actionParameters[j]);
                }
            }
            if (bi.actions[i].actionType == 3)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossBulletAttack(0, -1, bi.actions[i].actionParameters[j], 4);
                }
            }
            if (bi.actions[i].actionType == 4)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossBulletAttack(0, 1, bi.actions[i].actionParameters[j], 0);
                }
            }
            //Solid attack
            if (bi.actions[i].actionType == 5)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossSolidAttack(0, bi.actions[i].actionParameters[j], 9, bi.actions[i].actionParameters[j], -1, bi.actions[i].actionParameters[j], 0);
                }
            }
            if (bi.actions[i].actionType == 6)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossSolidAttack(9, bi.actions[i].actionParameters[j], 0, bi.actions[i].actionParameters[j], 10, bi.actions[i].actionParameters[j], 180);
                }
            }
            if (bi.actions[i].actionType == 7)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossSolidAttack(bi.actions[i].actionParameters[j], 4, bi.actions[i].actionParameters[j], 0, bi.actions[i].actionParameters[j], 5, 270);
                }
            }
            if (bi.actions[i].actionType == 8)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossSolidAttack(bi.actions[i].actionParameters[j], 0, bi.actions[i].actionParameters[j], 4, bi.actions[i].actionParameters[j], -1, 90);
                }
            }
        }
    }

    void BossBulletAttack(int xDirection, int yDirection, int xPos, int yPos)
    {
        GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2((xPos - xDirection) * GridManager.instance.gridSize.x, (yPos - yDirection) * GridManager.instance.gridSize.y), transform.rotation);
        go.GetComponent<EnemyGridBullet>().xDirection = xDirection;
        go.GetComponent<EnemyGridBullet>().yDirection = yDirection;
        go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
        go.GetComponent<EnemyGridBullet>().SetUp(xPos, yPos);
    }

    void BossSolidAttack(int x, int y, int midX, int midY, int endX, int endY, float rotationZ)
    {
        GameObject go = Instantiate(solidPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(endX * GridManager.instance.gridSize.x, endY * GridManager.instance.gridSize.y), transform.rotation);
        go.GetComponent<SolidAttack>().SetUp(x, y, midX, midY, endX, endY, solidDamage, solidAttackDelay, solidStayDelay, rotationZ);
    }
}
