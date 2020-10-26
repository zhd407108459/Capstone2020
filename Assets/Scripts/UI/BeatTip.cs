using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTip : MonoBehaviour
{
    public RectTransform imageTransform;
    public Transform abilityPosition;
    public GameObject shieldIcon;
    public GameObject meleeAttackIcon;
    //public GameObject bulletShootingIcon;

    private int abilityIndex = 0;

    public void ShowMeleeAttackIcon()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(true);
        //bulletShootingIcon.SetActive(false);
        meleeAttackIcon.transform.position = abilityPosition.position;
        abilityIndex = 1;
    }

    public void ShowShieldIcon()
    {
        shieldIcon.SetActive(true);
        meleeAttackIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        shieldIcon.transform.position = abilityPosition.position;
        abilityIndex = 2;
    }

    //public void ShowBulletShootingIcon()
    //{
    //    shieldIcon.SetActive(false);
    //    meleeAttackIcon.SetActive(false);
    //    bulletShootingIcon.SetActive(true);
    //    bulletShootingIcon.transform.position = abilityPosition.position;
    //    abilityIndex = 3;
    //}

    public void HideIcons()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        abilityIndex = 0;
    }

    public int AbilityIndex()
    {
        return abilityIndex;
    }
}
