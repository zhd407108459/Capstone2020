using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerBomb : RhythmObject
{
    public int delay;
    public int damage;
    public int xPos;
    public int yPos;
    public BoxCollider2D explosionArea;
    public GameObject bombParticlePrefab;
    public string explosionFXPath = "event:/FX/Enemy/FX-EnemyBomb";

    private int timer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);
        if(timer >= 0)
        {
            timer++;
            if(timer >= delay)
            {
                //Explode
                Explode();
            }
        }
    }

    public void Explode()
    {
        PlayerAction action = GameManager.instance.player.GetComponent<PlayerAction>();
        Collider2D[] cos = Physics2D.OverlapBoxAll(explosionArea.transform.position, new Vector2(explosionArea.size.x * explosionArea.transform.localScale.x, explosionArea.size.y * explosionArea.transform.localScale.y), explosionArea.transform.rotation.eulerAngles.z);
        bool ishit = false;
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Enemy"))
            {
                if (action.damageIncreasingRatio > 1)
                {
                    cos[i].GetComponent<BasicEnemy>().TakeDamage((int)(damage * action.damageIncreasingRatio));
                    ishit = true;
                }
                else
                {
                    cos[i].GetComponent<BasicEnemy>().TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();

            }
            if (cos[i].tag.Equals("BossComponent"))
            {
                if (action.damageIncreasingRatio > 1)
                {
                    GridManager.instance.boss.TakeDamage((int)(damage * action.damageIncreasingRatio));
                    ishit = true;
                }
                else
                {
                    GridManager.instance.boss.TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();

            }
            if (cos[i].tag.Equals("BossBomb"))
            {
                if (!cos[i].GetComponent<EnemyBomb>().isAttacked)
                {
                    Vector3 centerPos = GridManager.instance.boss.GetCenterPosition();
                    //Debug.Log(cos[i].transform.position.x - centerPos.x);
                    if ((cos[i].transform.position.x - centerPos.x >= 0 && transform.position.x - cos[i].transform.position.x >= 0) || (cos[i].transform.position.x - centerPos.x < 0 && transform.position.x - cos[i].transform.position.x <= 0))
                    {
                        cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(centerPos, true);
                    }
                    else
                    {
                        if (cos[i].transform.position.x - centerPos.x >= 0)
                        {
                            cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(cos[i].transform.position + new Vector3(5.0f, 0, 0), false);
                        }
                        else
                        {
                            cos[i].GetComponent<EnemyBomb>().AttackedByPlayer(cos[i].transform.position + new Vector3(-5.0f, 0, 0), false);
                        }
                    }
                    ishit = true;
                    Camera.main.GetComponent<CameraShake>().Shake();

                }
            }
            if (cos[i].tag.Equals("Player") && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
            {
                if (action.damageIncreasingRatio > 1)
                {
                    cos[i].GetComponent<PlayerHealth>().TakeDamage((int)(damage * action.damageIncreasingRatio));
                    ishit = true;
                }
                else
                {
                    cos[i].GetComponent<PlayerHealth>().TakeDamage(damage);
                }
                Camera.main.GetComponent<CameraShake>().Shake();

            }
        }
        if(ishit && action.damageIncreasingRatio > 1)
        {
            action.EndIncreasingDamage();
        }
        Instantiate(bombParticlePrefab, explosionArea.transform.position, explosionArea.transform.rotation);
        if (explosionFXPath != null && explosionFXPath != "")
        {
            EventInstance explosionFX;
            explosionFX = RuntimeManager.CreateInstance(explosionFXPath);
            if (SettingManager.instance != null)
            {
                float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                explosionFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
            }
            explosionFX.start();
        }
        Destroy(this.gameObject);
    }

    public override void OnSemiBeat(int lastBeatIndex)
    {
        base.OnSemiBeat(lastBeatIndex);
        if(timer == -1)
        {
            timer = 0;
        }
    }

    public void SetUp(int delay, int damage, int xPos, int yPos)
    {
        this.delay = delay;
        this.damage = damage;
        this.xPos = xPos;
        this.yPos = yPos;
        timer = -1;
        transform.position = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }
}
