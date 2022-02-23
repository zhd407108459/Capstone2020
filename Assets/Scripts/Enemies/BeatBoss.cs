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

    public int reflectBulletDamage;
    public GameObject reflectBulletPrefab;

    public GameObject shootCenterObject;
    public int centerShootPosX;
    public int centerShootPosY;
    public bool isUseCenterObjectPos;

    public int solidDamage;
    public GameObject solidPrefab;
    public int solidAttackDelay;
    public int solidStayDelay;

    public int laserDamage;
    public GameObject laserPrefab;
    public int laserAttackDelay;
    public int laserStayDelay;

    public int laser2Damage;
    public GameObject laser2Prefab;
    public int laser2AttackDelay;
    public int laser2StayDelay;

    public int bombDamage;
    public float bombRange;
    public int bombDelay;
    public GameObject bombPrefab;

    public int dollDamage;
    public int dollAttackDelay;
    public GameObject dollPrefab;

    public Boss3HookTracker bossHook;
    public int bossHookDamage;

    public List<GameObject> ropeHangingObjectPrefabList;

    public List<Transform> bombPositions = new List<Transform>();

    public List<GameObject> bossBuff = new List<GameObject>();
    public List<GameObject> bossDebuff = new List<GameObject>();

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
        HideBossComponents();
        if (bossHook != null)
        {
            bossHook.Initialize();
        }
    }

    public void Activate()
    {
        isActivated = true;
        canBeAttacked = false;
        healthSlider.gameObject.SetActive(false);
        resetAnimationEvent.Invoke();
        HideBossComponents();
        if (bossHook != null)
        {
            bossHook.Initialize();
        }
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
        HideBossComponents();
        if (bossHook != null)
        {
            bossHook.Initialize();
        }
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
        //endUIPanel.SetActive(true);
        GridManager.instance.PlayBossEndingCutScene();
        BeatsManager.instance.EndBGM();
        foreach (var n in FindObjectsOfType<EnemyGridBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyReflectionBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<PlayerGridBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<SolidAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossLaserAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyBomb>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossDollAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossRopeHangingObject>())
        {
            Destroy(n.gameObject);
        }
        if (SettingManager.instance != null)
        {
            if(SettingManager.instance.levelProcess == GridManager.instance.levelIndex)
            {
                SettingManager.instance.levelProcess += 1;
                SettingManager.instance.phaseProcess = 1;
                SettingManager.instance.SaveToPath();
            }
        }
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
        if (bossHook != null)
        {
            bossHook.Initialize();
        }
    }

    public Vector3 GetCenterPosition()
    {
        if (!isUseCenterObjectPos)
        {
            Vector3 centerPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(centerShootPosX * GridManager.instance.gridSize.x, centerShootPosY * GridManager.instance.gridSize.y);
            return centerPos;
        }
        else
        {
            Vector3 centerPos = shootCenterObject.transform.position;
            return centerPos;
        }
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
            //Doll Attack
            if(bi.actions[i].actionType == 13 && dollPrefab != null)
            {
                DollAttack(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos, GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos);
            }
            //Shoot Bullet From A Certain Position
            if (bi.actions[i].actionType == 14)
            {
                if(bi.actions[i].actionParameters.Count >= 3)
                {
                    ShootBulletFromPosition(bi.actions[i].actionParameters[0], bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2]);
                }
                else
                {
                    Debug.LogError("Wrong action parameters count. Action type: 14. Index: " + bi.index);
                }
            }
            //Rope hanging object
            if (bi.actions[i].actionType == 15 && ropeHangingObjectPrefabList != null)
            {
                if (bi.actions[i].actionParameters.Count >= 4)
                {
                    RopeHangingObject(bi.actions[i].actionParameters[0], bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2], bi.actions[i].actionParameters[3]);
                }
                else
                {
                    Debug.LogError("Wrong action parameters count. Action type: 15. Index: " + bi.index);
                }
            }
            //Reflection Bullet attack
            if (bi.actions[i].actionType == 16)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossReflectBulletAttack(1, 0, 0, bi.actions[i].actionParameters[j], 2);
                }
            }
            if (bi.actions[i].actionType == 17)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossReflectBulletAttack(-1, 0, 9, bi.actions[i].actionParameters[j], 1);
                }
            }
            if (bi.actions[i].actionType == 18)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossReflectBulletAttack(0, -1, bi.actions[i].actionParameters[j], 4, 3);
                }
            }
            if (bi.actions[i].actionType == 19)
            {
                for (int j = 0; j < bi.actions[i].actionParameters.Count; j++)
                {
                    BossReflectBulletAttack(0, 1, bi.actions[i].actionParameters[j], 0, 4);
                }
            }
            if(bi.actions[i].actionType == 20)
            {
                BossHookAttack();
            }
            if (bi.actions[i].actionType == 21)
            {
                if(bi.actions[i].actionParameters.Count >= 3)
                {
                    BossLaserAttack(4, bi.actions[i].actionParameters[0], 0, bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2]);
                }
                else
                {
                    BossLaserAttack(4, bi.actions[i].actionParameters[0], 0, 0, 0);
                }
            }
            if (bi.actions[i].actionType == 22)
            {
                if (bi.actions[i].actionParameters.Count >= 3)
                {
                    BossLaserAttack(bi.actions[i].actionParameters[0], 2, 90, bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2]);
                }
                else
                {
                    BossLaserAttack(bi.actions[i].actionParameters[0], 2, 90, 0, 0);
                }
            }
            if (bi.actions[i].actionType == 23)
            {
                if (bi.actions[i].actionParameters.Count >= 3)
                {
                    GenerateBossBuff(bi.actions[i].actionParameters[0], bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2]);
                }
                else
                {
                    Debug.LogError("Wrong Parameters!");
                }
            }
            if (bi.actions[i].actionType == 24)
            {
                if (bi.actions[i].actionParameters.Count >= 3)
                {
                    GenerateBossDebuff(bi.actions[i].actionParameters[0], bi.actions[i].actionParameters[1], bi.actions[i].actionParameters[2]);
                }
                else
                {
                    Debug.LogError("Wrong Parameters!");
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
    void BossReflectBulletAttack(int xDirection, int yDirection, int xPos, int yPos, int targetWall)
    {
        if (reflectBulletPrefab == null)
        {
            Debug.LogError("Prefab isn't set!!");
            return;
        }
        GameObject go = Instantiate(reflectBulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2((xPos - xDirection) * GridManager.instance.gridSize.x, (yPos - yDirection) * GridManager.instance.gridSize.y), transform.rotation);
        go.GetComponent<EnemyReflectionBullet>().xDirection = xDirection;
        go.GetComponent<EnemyReflectionBullet>().yDirection = yDirection;
        go.GetComponent<EnemyReflectionBullet>().damage = (int)(reflectBulletDamage);
        go.GetComponent<EnemyReflectionBullet>().targetWall = targetWall;
        go.GetComponent<EnemyReflectionBullet>().SetUp(xPos, yPos);
        go.GetComponent<EnemyReflectionBullet>().SetBulletRotation();
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
            Debug.LogError("Wrong Boss Component Index: " + index);
            return;
        }
        bossComponents[index].GetComponent<BossComponent>().Show(1);
    }

    void HideBossComponents()
    {
        for(int i = 0; i < bossComponents.Count; i++)
        {
            bossComponents[i].SetActive(false);
        }
    }

    void ThrowBomb(int index)
    {
        if(index >= bombPositions.Count)
        {
            Debug.LogError("Wrong Boss Bomb Position Index: " + index);
            return;
        }
        GameObject go = Instantiate(bombPrefab, bombPositions[index].position, bombPositions[index].rotation);
        go.GetComponent<EnemyBomb>().SetUp(bombDelay, bombDamage, bombRange);
    }

    void ShootBulletFromCenter(int direction)
    {
        if(direction >= 8)
        {
            Debug.LogError("Wrong Direction: " + direction);
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

    void ShootBulletFromPosition(int direction, int x, int y)
    {
        if (direction >= 8)
        {
            Debug.LogError("Wrong Direction: " + direction);
            return;
        }
        if(x < 0 || y < 0 || x > 9 || y > 4)
        {
            Debug.LogError("Wrong Position: " + x + ", " + y);
            return;
        }
        GameObject go = Instantiate(bulletPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(x * GridManager.instance.gridSize.x, y * GridManager.instance.gridSize.y), transform.rotation);
        if (direction == 0 || direction == 1 || direction == 7)
        {
            go.GetComponent<EnemyGridBullet>().xDirection = 1;
        }
        else if (direction == 3 || direction == 4 || direction == 5)
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
        go.GetComponent<EnemyGridBullet>().SetUp(x + go.GetComponent<EnemyGridBullet>().xDirection, y + go.GetComponent<EnemyGridBullet>().yDirection);
        go.GetComponent<EnemyGridBullet>().SetBulletRotation();
    }

    void InvokeBossEvent(int index)
    {
        if(index >= bossEvents.Count)
        {
            Debug.LogError("Wrong Index: " + index);
            return;
        }
        bossEvents[index].Invoke();
    }

    void DollAttack(int x, int y)
    {
        GameObject go = Instantiate(dollPrefab);
        go.GetComponent<BossDollAttack>().damage = dollDamage;
        go.GetComponent<BossDollAttack>().attackDelay = dollAttackDelay;
        go.GetComponent<BossDollAttack>().SetUp(x, y);
    }

    void RopeHangingObject(int delay, int x, int y, int index)
    {
        if(index >= ropeHangingObjectPrefabList.Count)
        {
            Debug.LogError("Wrong Index: " + index);
            return;
        }
        GameObject go = Instantiate(ropeHangingObjectPrefabList[index]);
        go.GetComponent<BossRopeHangingObject>().stayDelay = delay;
        go.GetComponent<BossRopeHangingObject>().SetUp(x, y);
    }

    void BossHookAttack()
    {
        if (bossHook != null)
        {
            bossHook.damage = bossHookDamage;
            bossHook.SetUp(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos, 0);
        }
    }

    void BossLaserAttack(int x, int y, float rotationZ, int colorIndex, int lengthIndex)
    {
        if(lengthIndex == 0)
        {
            GameObject go = Instantiate(laserPrefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(x * GridManager.instance.gridSize.x, y * GridManager.instance.gridSize.y), transform.rotation);
            go.GetComponent<BossLaserAttack>().SetUp(x, y, laserDamage, laserAttackDelay, laserStayDelay, rotationZ, 0);
        }
        else
        {
            GameObject go = Instantiate(laser2Prefab, GridManager.instance.GetPhaseInitialPosition() + new Vector2(x * GridManager.instance.gridSize.x, y * GridManager.instance.gridSize.y), transform.rotation);
            go.GetComponent<BossLaserAttack>().SetUp(x, y, laser2Damage, laser2AttackDelay, laser2StayDelay, rotationZ, 1);
        }
    }

    void GenerateBossBuff(int itemIndex, int x, int y)
    {
        if(itemIndex < 0 || itemIndex >= bossBuff.Count || x<0 || x > 9 || y < 0 || y > 4)
        {
            Debug.LogError("Wrong Parameters!");
        }
        GameObject go = Instantiate(bossBuff[itemIndex], GridManager.instance.GetPhaseInitialPosition() + new Vector2(x * GridManager.instance.gridSize.x, y * GridManager.instance.gridSize.y), Quaternion.identity);
        go.GetComponent<BasicBuff>().Setup(x, y);
    }

    void GenerateBossDebuff(int itemIndex, int x, int y)
    {
        if (itemIndex < 0 || itemIndex >= bossDebuff.Count || x < 0 || x > 9 || y < 0 || y > 4)
        {
            Debug.LogError("Wrong Parameters!");
        }
        GameObject go = Instantiate(bossDebuff[itemIndex], GridManager.instance.GetPhaseInitialPosition() + new Vector2(x * GridManager.instance.gridSize.x, y * GridManager.instance.gridSize.y), Quaternion.identity);
        go.GetComponent<BasicDebuff>().Setup(x, y);
    }
}
