using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTip : MonoBehaviour
{
    public List<Transform> abilityPositions = new List<Transform>();
    public GameObject shieldIcon;
    public GameObject meleeAttackIcon;

    [HideInInspector] public int abilityCount = 0;

    public void ShowShieldIcon()
    {
        shieldIcon.SetActive(true);
        shieldIcon.transform.position = abilityPositions[abilityCount].position;
        abilityCount++;
    }

    public void ShowMeleeAttackIcon()
    {
        meleeAttackIcon.SetActive(true);
        meleeAttackIcon.transform.position = abilityPositions[abilityCount].position;
        abilityCount++;
    }
}
