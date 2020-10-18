using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTip : MonoBehaviour
{
    public RectTransform imageTransform;
    public Transform abilityPosition;
    public GameObject shieldIcon;
    public GameObject meleeAttackIcon;

    private int abilityIndex = 0;

    public void ShowShieldIcon()
    {
        shieldIcon.SetActive(true);
        meleeAttackIcon.SetActive(false);
        shieldIcon.transform.position = abilityPosition.position;
        abilityIndex = 2;
    }

    public void ShowMeleeAttackIcon()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(true);
        meleeAttackIcon.transform.position = abilityPosition.position;
        abilityIndex = 1;
    }

    public void HideIcons()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(false);
        abilityIndex = 0;
    }

    public int AbilityIndex()
    {
        return abilityIndex;
    }
}
