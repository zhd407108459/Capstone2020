using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : RhythmObject
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D shieldBox;
    public float actionTolerance;
    public KeyCode triggerKey;
    public bool isAutoUse;

    private PlayerAction action;

    void Start()
    {
        HideShield();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (!isAutoUse)
        {
            if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && availability[BeatsManager.instance.GetIndexToNearestBeat()])
            {
                if (Input.GetKeyDown(triggerKey))
                {
                    UseShield();
                }
            }
        }
            
    }

    public override void OnBeat(int beatIndex)
    {
        if (isAutoUse && availability[beatIndex])
        {
            UseShield();
        }
    }

    void ChangeBeatTips()
    {
        for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if (availability[i])
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon(); ;
            }
        }
    }

    void UseShield()
    {
        shieldBox.gameObject.SetActive(true);
        Collider2D[] cos = Physics2D.OverlapBoxAll(shieldBox.transform.position, new Vector2(shieldBox.size.x * shieldBox.transform.localScale.x, shieldBox.size.y * shieldBox.transform.localScale.y), shieldBox.transform.rotation.eulerAngles.z);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("EnemyBullet"))
            {
                Destroy(cos[i].gameObject);
            }
        }
        //action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideShield", existingTime);
    }

    void HideShield()
    {
        shieldBox.gameObject.SetActive(false);
    }
}
