using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;

public class EnemyDeathBuffParticle : MonoBehaviour
{

    public UnityEvent events;
    public BasicEnemy targetEnemy;

    public float burstDistance;
    public float burstDelay;

    public string triggerFXPath = "event:/FX/Enemy/FX-EnemyShield";

    private int isMoveToEnemy;

    private Vector3 burstPosition;
    private GameObject buffIconPrefab;

    private string content;

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (!targetEnemy.gameObject.activeSelf)
        {
            Destroy(this.gameObject);
        }
        if (isMoveToEnemy == 0)
        {
            transform.position = Vector3.Lerp(transform.position, burstPosition, 15.0f * Time.deltaTime);
            if(Vector3.Distance(transform.position, burstPosition) < 0.02f)
            {
                isMoveToEnemy = 1;
                Invoke("EndBurstDelay", burstDelay);
            }
        }
        else if (isMoveToEnemy == 2)
        {
            transform.position = Vector3.Lerp(transform.position, targetEnemy.transform.position, 15.0f * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) < 0.02f)
            {
                events.Invoke();
                if(triggerFXPath != null && triggerFXPath != "")
                {
                    EventInstance buffFX;
                    buffFX = RuntimeManager.CreateInstance(triggerFXPath);
                    if (SettingManager.instance != null)
                    {
                        float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                        buffFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume * (1.0f - value));
                    }
                    buffFX.start();
                }
                if (buffIconPrefab != null)
                {
                    GameObject go = Instantiate(buffIconPrefab, targetEnemy.transform.position, targetEnemy.transform.rotation);
                    go.GetComponent<DeathrattleIcon>().SetUp(content);
                }
                Destroy(this.gameObject);
            }
        }
    }

    void EndBurstDelay()
    {
        isMoveToEnemy = 2;
    }

    public void SetUp(UnityEvent e, BasicEnemy enemy, GameObject iconPrefab, string content)
    {
        events = e;
        targetEnemy = enemy;
        buffIconPrefab = iconPrefab;
        isMoveToEnemy = 0;
        burstPosition = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        burstPosition = burstPosition.normalized * burstDistance + transform.position;
        this.content = content;
    }
}
