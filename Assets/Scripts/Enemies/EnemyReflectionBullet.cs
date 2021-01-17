using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class EnemyReflectionBullet : RhythmObject
{
    public float movementLerpValue;

    public int damage;
    public GameObject bounceOffBulletPrefab;

    public int xDirection;
    public int yDirection;

    [HideInInspector] public int xPos;
    [HideInInspector] public int yPos;
    [HideInInspector] public int originalXPos;
    [HideInInspector] public int originalYPos;

    [HideInInspector] public BasicEnemy owner;

    public string shieldImpactFXEventPath = "event:/FX/Player/FX-ShieldImpact";

    private bool isReflected = false;

    private Vector3 targetPos;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (Vector2.Distance(transform.position, targetPos) > 0.0001f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementLerpValue * Time.deltaTime);
            if (!isReflected && 
                ((transform.position.x <= GridManager.instance.GetPhaseInitialPosition().x - 0.5f * GridManager.instance.gridSize.x) 
                || (transform.position.x >= GridManager.instance.GetPhaseInitialPosition().x + 9.5f * GridManager.instance.gridSize.x) 
                || (transform.position.y <= GridManager.instance.GetPhaseInitialPosition().y - 0.5f * GridManager.instance.gridSize.y) 
                || (transform.position.y >= GridManager.instance.GetPhaseInitialPosition().y + 4.5f * GridManager.instance.gridSize.y)))
            {
                isReflected = true;
                xDirection = -xDirection;
                yDirection = -yDirection;
                xPos += xDirection;
                yPos += yDirection;
                targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
            }
        }
        if (Vector2.Distance(transform.position, targetPos) < 0.005f && xPos == originalXPos && yPos == originalYPos)
        {
            if (owner.gameObject.activeSelf)
            {
                if (owner.isActivated)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        Move();
    }

    public void SetUp(int x, int y)
    {
        xPos = x;
        yPos = y;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }

    public void Move()
    {
        xPos += xDirection;
        yPos += yDirection;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        if (xPos <= -2 || xPos >= 12 || yPos <= -2 || yPos >= 7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (collision.tag.Equals("PlayerShield"))
        {
            EventInstance shieldImpactFX;
            shieldImpactFX = RuntimeManager.CreateInstance(shieldImpactFXEventPath);
            if (SettingManager.instance != null)
            {
                shieldImpactFX.setVolume(SettingManager.instance.overAllVolume);
            }
            shieldImpactFX.start();

            GameObject go = Instantiate(bounceOffBulletPrefab, transform.position, transform.rotation);
            go.GetComponent<PlayerGridBullet>().xDirection = -xDirection;
            go.GetComponent<PlayerGridBullet>().yDirection = -yDirection;
            go.GetComponent<PlayerGridBullet>().SetUp(xPos - xDirection, yPos - yDirection);
            go.GetComponent<PlayerGridBullet>().damage = damage;
            Camera.main.GetComponent<CameraShake>().Shake();
            Destroy(this.gameObject);
        }
    }
}