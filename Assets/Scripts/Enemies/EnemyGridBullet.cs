using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class EnemyGridBullet : RhythmObject
{
    public float movementLerpValue;

    public int damage;
    public GameObject bounceOffBulletPrefab;
    public GameObject bounceOffEffectPrefab;

    public GameObject sprite;

    public int xDirection;
    public int yDirection;

    [HideInInspector] public int xPos;
    [HideInInspector] public int yPos;

    public string shieldImpactFXEventPath = "event:/FX/Player/FX-ShieldImpact";

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
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        Move();
        if (sprite.GetComponent<Animator>() != null) 
        {
            sprite.GetComponent<Animator>().SetTrigger("Change");
            
        }
    }

    public void SetUp(int x, int y)
    {
        xPos = x;
        yPos = y;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }

    public void SetBulletRotation()
    {
        if(xDirection > 0 && yDirection == 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            return;
        }
        if (xDirection < 0 && yDirection == 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            return;
        }
        if (xDirection == 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            return;
        }
        if (xDirection == 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
            return;
        }
        if (xDirection > 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            return;
        }
        if (xDirection < 0 && yDirection > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            return;
        }
        if (xDirection < 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 225.0f);
            return;
        }
        if (xDirection > 0 && yDirection < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
            return;
        }
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
            go.GetComponent<PlayerGridBullet>().xDirection = (GameManager.instance.player.GetComponent<PlayerGridMovement>().isPlayerFacingRight ? Mathf.Abs(xDirection) : -Mathf.Abs(xDirection));
            go.GetComponent<PlayerGridBullet>().yDirection = -yDirection;
            go.GetComponent<PlayerGridBullet>().SetUp(xPos - ((go.GetComponent<PlayerGridBullet>().xDirection == xDirection) ? 0 : xDirection), yPos - yDirection);
            go.GetComponent<PlayerGridBullet>().damage = damage;
            go.GetComponent<PlayerGridBullet>().SetBulletRotation();
            Camera.main.GetComponent<CameraShake>().Shake();

            if(bounceOffEffectPrefab != null)
            {
                GameObject effect = Instantiate(bounceOffEffectPrefab, transform.position, transform.rotation);
                if(xDirection > 0)
                {
                    effect.transform.rotation = Quaternion.Euler(0, 0, 180);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(180.0f);
                }
                else if(xDirection < 0)
                {
                    effect.transform.rotation = Quaternion.Euler(0, 0, 0);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(0.0f);
                }
                else if(yDirection > 0)
                {
                    effect.transform.rotation = Quaternion.Euler(0, 0, -90);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(90.0f);
                }
                else
                {
                    effect.transform.rotation = Quaternion.Euler(0, 0, 90);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(-90.0f);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
