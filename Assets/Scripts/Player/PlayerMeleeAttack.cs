using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D meleeAttackBox;
    public int damage;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    private PlayerAction action;

    void Start()
    {
        if(SettingManager.instance != null)
        {
            isAutoUse = SettingManager.instance.isAutoAttack;
        }
        HideMeleeAttackBox();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (!isAutoUse)
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && availability[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused)//!action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()])// 
            {
                if (Input.GetKeyDown(triggerKey))
                {
                    MeleeAttack();
                }
            }
        }
        if (meleeAttackBox.gameObject.activeSelf)
        {
            Attack();
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if(isAutoUse && availability[beatIndex] && GridManager.instance.isInPhase && !action.isDizzy)
        {
            MeleeAttack();
        }
    }

    void ChangeBeatTips()
    {
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowMeleeAttackIcon(); ;
            }
        }
    }
    void MeleeAttack()
    {
        meleeAttackBox.gameObject.SetActive(true);
        //action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideMeleeAttackBox", existingTime);
    }

    void Attack()
    {
        Collider2D[] cos = Physics2D.OverlapBoxAll(meleeAttackBox.transform.position, new Vector2(meleeAttackBox.size.x * meleeAttackBox.transform.localScale.x, meleeAttackBox.size.y * meleeAttackBox.transform.localScale.y), meleeAttackBox.transform.rotation.eulerAngles.z);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Enemy"))
            {
                if (!cos[i].GetComponent<BasicEnemy>().isMeleeAttacked)
                {
                    if(action.damageIncreasingRatio > 1)
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage((int)(damage * action.damageIncreasingRatio));
                        action.EndIncreasingDamage();
                    }
                    else
                    {
                        cos[i].GetComponent<BasicEnemy>().TakeDamage(damage);
                    }
                    cos[i].GetComponent<BasicEnemy>().MeleeAttacked();
                }
            }
        }
    }

    void HideMeleeAttackBox()
    {
        meleeAttackBox.gameObject.SetActive(false);
    }

    public void SetSingleAvalibility(int n)
    {
        for(int i = 0; i < availability.Count; i++)
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
}
