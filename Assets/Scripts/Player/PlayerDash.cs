using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerDash : MonoBehaviour
{
    public List<bool> availability = new List<bool>();
    public int damage;
    public GameObject dashEffectPrefab;
    public GameObject hitEffectPrefab;
    [HideInInspector] public bool isDashing;

    public string dashFXEventPath = "event:/FX/Player/FX-Dash";

    void Start()
    {
        isDashing = false;
        ChangeBeatTips();
    }

    void ChangeBeatTips()
    {
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowDashIcon();
            }
        }
    }
    public void SetSingleAvalibility(int n)
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
        availability[n] = true;
    }

    public void ClearAvalibility()
    {
        for (int i = 0; i < availability.Count; i++)
        {
            availability[i] = false;
        }
    }

    public void StartDash()
    {
        isDashing = true;

        EventInstance dashFX;
        dashFX = RuntimeManager.CreateInstance(dashFXEventPath);
        if (SettingManager.instance != null)
        {
            dashFX.setVolume(SettingManager.instance.overAllVolume);
        }
        dashFX.start();
        Invoke("EndDash", 0.4f);
        if(dashEffectPrefab != null)
        {
            GameObject effect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);
            if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
            {
                effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
            }
        }
    }

    public void EndDash()
    {
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDashing)
        {
            return;
        }
        if (collision.tag.Equals("Enemy"))
        {
            if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
            {
                collision.GetComponent<BasicEnemy>().TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
            }
            else
            {
                collision.GetComponent<BasicEnemy>().TakeDamage(damage);
            }
            if (hitEffectPrefab != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                if (!GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                {
                    effect.transform.localScale = new Vector3(-effect.transform.localScale.x, effect.transform.localScale.y, effect.transform.localScale.z);
                }
            }
        }
        if (collision.tag.Equals("BossComponent"))
        {
            if (GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio > 1)
            {
                GridManager.instance.boss.TakeDamage((int)(damage * GameManager.instance.player.GetComponent<PlayerAction>().damageIncreasingRatio));
                GameManager.instance.player.GetComponent<PlayerAction>().EndIncreasingDamage();
            }
            else
            {
                GridManager.instance.boss.TakeDamage(damage);
            }
        }
    }
}
