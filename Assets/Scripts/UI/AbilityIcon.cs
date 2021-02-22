using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    public GameObject shieldIcon;
    public GameObject meleeAttackIcon;
    public GameObject dashIcon;
    public GameObject throwBombIcon;
    public KeyCode triggerKey;
    public Text keyText;
    public GameObject leftMouseButtonIcon;
    public GameObject rightMouseButtonIcon;

    public List<GameObject> abilityCoolDown = new List<GameObject>();
    public GameObject abilityCharged;
    [HideInInspector] public int coolDownTimer;
    [HideInInspector] public bool isCoolDown;

    private int abilityIndex = 0;

    public void ShowMeleeAttackIcon()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(true);
        dashIcon.SetActive(false);
        throwBombIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        abilityIndex = 1;
    }

    public void ShowShieldIcon()
    {
        shieldIcon.SetActive(true);
        meleeAttackIcon.SetActive(false);
        dashIcon.SetActive(false);
        throwBombIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        abilityIndex = 2;
    }

    public void ShowDashIcon()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(false);
        dashIcon.SetActive(true);
        throwBombIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        abilityIndex = 3;
    }

    public void ShowThrowBombIcon()
    {
        shieldIcon.SetActive(false);
        meleeAttackIcon.SetActive(false);
        dashIcon.SetActive(false);
        throwBombIcon.SetActive(true);
        abilityIndex = 4;
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
        dashIcon.SetActive(false);
        throwBombIcon.SetActive(false);
        //bulletShootingIcon.SetActive(false);
        abilityIndex = 0;
    }

    public int AbilityIndex()
    {
        return abilityIndex;
    }

    public void StartCoolDown()
    {
        for(int i = 0; i < abilityCoolDown.Count; i++)
        {
            abilityCoolDown[i].SetActive(false);
        }
        abilityCharged.SetActive(false);
        coolDownTimer = 0;
        isCoolDown = false;
    }

    public void ChargeAbility()
    {
        if(coolDownTimer < abilityCoolDown.Count)
        {
            if (GameManager.instance.player.GetComponent<PlayerAction>().IsQuickCharge())
            {
                coolDownTimer += 2;
                if(coolDownTimer > abilityCoolDown.Count)
                {
                    coolDownTimer = abilityCoolDown.Count;
                }
            }
            else
            {
                coolDownTimer++;
            }
            for (int i = 0; i < coolDownTimer; i++)
            {
                abilityCoolDown[i].SetActive(true);
            }
        }
    }

    public void Charged()
    {
        abilityCharged.SetActive(true);
        isCoolDown = true;
    }

    public void ShowAllCoolDown()
    {
        for (int i = 0; i < abilityCoolDown.Count; i++)
        {
            abilityCoolDown[i].SetActive(true);
        }
        abilityCharged.SetActive(true);
        coolDownTimer = abilityCoolDown.Count;
        isCoolDown = true;
    }

    public void SetKeyTip(KeyCode key)
    {
        leftMouseButtonIcon.SetActive(false);
        rightMouseButtonIcon.SetActive(false);
        if(key == KeyCode.None)
        {
            keyText.text = "";
        }
        else if(key == KeyCode.Mouse0)
        {
            keyText.text = "";
            leftMouseButtonIcon.SetActive(true);
        }
        else if (key == KeyCode.Mouse1)
        {
            keyText.text = "";
            rightMouseButtonIcon.SetActive(true);
        }
        else
        {
            keyText.text = key.ToString();
        }
    }
}
