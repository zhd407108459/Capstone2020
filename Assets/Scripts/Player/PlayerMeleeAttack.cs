using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public List<bool> availability = new List<bool>();
    public float existingTime;
    public BoxCollider2D meleeAttackBox;
    public float actionTolerance;
    public KeyCode triggerKey;

    private PlayerAction action;

    void Start()
    {
        HideMeleeAttackBox();
        action = GetComponent<PlayerAction>();
        ChangeBeatTips();
    }

    void Update()
    {
        if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && availability[BeatsManager.instance.GetIndexToNearestBeat()])
        {
            if (Input.GetKeyDown(triggerKey))
            {
                MeleeAttack();
            }
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
                Destroy(cos[i].gameObject);
            }
        }
        action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;
        Invoke("HideMeleeAttackBox", existingTime);
    }

    void HideMeleeAttackBox()
    {
        meleeAttackBox.gameObject.SetActive(false);
    }
}
