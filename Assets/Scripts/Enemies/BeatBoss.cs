using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BeatBoss : MonoBehaviour
{
    public int maxHealth;
    public Slider healthSlider;
    public List<GameObject> bossComponents = new List<GameObject>();

    public int bulletDamage;
    public GameObject bulletPrefab;

    public GameObject shootCenterObject;
    public int centerShootPosX;
    public int centerShootPosY;

    public int solidDamage;
    public GameObject solidPrefab;
    public int solidAttackDelay;
    public int solidStayDelay;

    public int bombDamage;
    public float bombRange;
    public int bombDelay;
    public GameObject bombPrefab;

    public List<Transform> bombPositions = new List<Transform>();

    public UnityEvent resetAnimationEvent;
    public UnityEvent bossHurtEvent;
    public List<UnityEvent> bossEvents = new List<UnityEvent>();

    public GameObject endUIPanel;

    [HideInInspector] public bool isMeleeAttacked;

    [HideInInspector] public bool isActivated;

    [HideInInspector] public bool canBeAttacked;

    [HideInInspector] public int health;

    private int currentIndex;

    void Start()
    {
        health = maxHealth;
        isActivated = false;
        healthSlider.gameObject.SetActive(false);
        resetAnimationEvent.Invoke();
    }

    public void Activate()
    {
        isActivated = true;
        canBeAttacked = false;
        healthSlider.gameObject.SetActive(false);
        resetAnimationEvent.Invoke();

    }

    public void Reset()
    {
        isActivated = false;
        if (canBeAttacked)
        {
            health = maxHealth;
            healthSlider.value = (float)health / (float)maxHealth;
        }
        else
        {
            healthSlider.gameObject.SetActive(false);
        }
        resetAnimationEvent.Invoke();
    }

    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (!canBeAttacked)
        {
            return;
        }
        health -= damage;
        bossHurtEvent.Invoke();
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = (float)health / (float)maxHealth;
    }

    public void Die()
    {
        //Debug.Log("BossDie");
        endUIPanel.SetActive(true);
        GameManager.instance.isGameEnd = true;
        GameManager.instance.isPaused = true;
    }

    public void MeleeAttacked()
    {
        isMeleeAttacked = true;
        Invoke("TurnOffIsMeleeAttacked", 0.4f);
    }

    void TurnOffIsMeleeAttacked()
    {
        isMeleeAttacked = false;
    }

    public void StartStage2()
    {
        health = maxHealth;
        healthSlider.value = (float)health / (float)maxHealth;
        canBeAttacked = true;
        healthSlider.gameObject.SetActive(true);
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
        currentIndex = index;
        shootCenterObject.SetActive(false);
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
            //Show Components
            if (bi.actions[i].actionType == 9)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    ShowComponent(bi.actions[i].actionParameters[j]);
                }
            }
            //Throw Bombs
            if(bi.actions[i].actionType == 10)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    ThrowBomb(bi.actions[i].actionParameters[j]);
                }
            }
            //Shoot Bullet From Center
            if (bi.actions[i].actionType == 11)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    ShootBulletFromCenter(bi.actions[i].actionParameters[j]);
                }
            }
            //BossEvent
            if (bi.actions[i].actionType == 12)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    InvokeBossEvent(bi.actions[i].actionParameters[j]);
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
        go.GetComponent<EnemyGridBullet>().SetBulletRotation();
    }

    void BossSolidAttack(int x, int y, int midX, int midY, int endX, int endY, float rotationZ)
    {
        GameObject go = Instantiate(solidPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(endX * GridManager.instance.gridSize.x, endY * GridManager.instance.gridSize.y), transform.rotation);
        go.GetComponent<SolidAttack>().SetUp(x, y, midX, midY, endX, endY, solidDamage, solidAttackDelay, solidStayDelay, rotationZ);
    }
    
    void ShowComponent(int index)
    {
        if(index >= bossComponents.Count)
        {
            Debug.Log("Wrong Boss Component Index: " + index);
            return;
        }
        bossComponents[index].GetComponent<BossComponent>().Show(1);
    }

    void ThrowBomb(int index)
    {
        if(index >= bombPositions.Count)
        {
            Debug.Log("Wrong Boss Bomb Position Index: " + index);
            return;
        }
        GameObject go = Instantiate(bombPrefab, bombPositions[index].position, bombPositions[index].rotation);
        go.GetComponent<EnemyBomb>().SetUp(bombDelay, bombDamage, bombRange);
    }

    void ShootBulletFromCenter(int direction)
    {
        if(direction >= 8)
        {
            Debug.Log("Wrong Direction: " + direction);
            return;
        }
        shootCenterObject.SetActive(true);
        GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(centerShootPosX * GridManager.instance.gridSize.x, centerShootPosY * GridManager.instance.gridSize.y), transform.rotation);
        if(direction == 0 || direction == 1 || direction == 7)
        {
            go.GetComponent<EnemyGridBullet>().xDirection = 1;
        }
        else if(direction == 3 || direction == 4 || direction == 5)
        {
            go.GetComponent<EnemyGridBullet>().xDirection = -1;
        }
        else
        {
            go.GetComponent<EnemyGridBullet>().xDirection = 0;
        }
        if (direction == 1 || direction == 2 || direction == 3)
        {
            go.GetComponent<EnemyGridBullet>().yDirection = 1;
        }
        else if (direction == 5 || direction == 6 || direction == 7)
        {
            go.GetComponent<EnemyGridBullet>().yDirection = -1;
        }
        else
        {
            go.GetComponent<EnemyGridBullet>().yDirection = 0;
        }
        go.GetComponent<EnemyGridBullet>().damage = (int)(bulletDamage);
        go.GetComponent<EnemyGridBullet>().SetUp(centerShootPosX + go.GetComponent<EnemyGridBullet>().xDirection, centerShootPosY + go.GetComponent<EnemyGridBullet>().yDirection);
        go.GetComponent<EnemyGridBullet>().SetBulletRotation();
    }

    void InvokeBossEvent(int index)
    {
        if(index >= bossEvents.Count)
        {
            Debug.Log("Wrong Index: " + index);
            return;
        }
        bossEvents[index].Invoke();
    }
}
