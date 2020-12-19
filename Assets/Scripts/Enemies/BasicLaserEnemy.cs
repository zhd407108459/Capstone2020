using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BasicLaserEnemy : BasicEnemy
{
    public GameObject laserObject;
    public BoxCollider2D laserCollider;

    public List<bool> shootBeats = new List<bool>();
    public List<bool> ragedShootBeats = new List<bool>();

    public string enemyLaserAttackFXEventPath = "event:/FX/Enemy/FX-EnemyLaser";

    void Start()
    {
        laserObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public override void Activate()
    {
        base.Activate();
        laserObject.SetActive(false);
    }
    public override void OnBeat(int beatIndex)
    {
        if (!isActivated || GameManager.instance.isPaused)
        {
            return;
        }
        if ((shootBeats[beatIndex] && !isRaged) || (ragedShootBeats[beatIndex] && isRaged))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        EventInstance enemyLaserAttackFX;
        enemyLaserAttackFX = RuntimeManager.CreateInstance(enemyLaserAttackFXEventPath);
        if (SettingManager.instance != null)
        {
            float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            enemyLaserAttackFX.setVolume(SettingManager.instance.overAllVolume * (1.0f - value));
        }
        enemyLaserAttackFX.start();

        laserObject.SetActive(true);
        Collider2D[] cos = Physics2D.OverlapBoxAll(laserCollider.transform.position, new Vector2(laserCollider.size.x * laserCollider.transform.localScale.x, laserCollider.size.y * laserCollider.transform.localScale.y), laserCollider.transform.rotation.eulerAngles.z);
        for(int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Player"))
            {
                cos[i].GetComponent<PlayerHealth>().TakeDamage((int)(damage * damageIncreasement));
                Invoke("HideLaserObject", 0.3f);
                return;
            }
        }
        Invoke("HideLaserObject", 0.3f);
    }

    void HideLaserObject()
    {
        laserObject.SetActive(false);
    }
}
