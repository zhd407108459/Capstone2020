using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D meleeAttackBox;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    private PlayerAction action;

    void Start()
    {
        HideMeleeAttackBox();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (!isAutoUse)
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && availability[BeatsManager.instance.GetIndexToNearestBeat()])//!action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()])// 
            {
                if (Input.GetKeyDown(triggerKey))
                {
                    MeleeAttack();
                }
            }
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if(isAutoUse && availability[beatIndex])
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
        Collider2D[] cos = Physics2D.OverlapBoxAll(meleeAttackBox.transform.position, new Vector2(meleeAttackBox.size.x * meleeAttackBox.transform.localScale.x, meleeAttackBox.size.y * meleeAttackBox.transform.localScale.y), meleeAttackBox.transform.rotation.eulerAngles.z);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("Enemy"))
            {
                cos[i].GetComponent<BasicEnemy>().Die();
            }
        }
        //action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideMeleeAttackBox", existingTime);
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
