using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class SetAbilities : MonoBehaviour
{

    public GameObject preBattlePanel;
    public Transform targetBeatsContainerPosition;
    public Transform originalBeatsContainerPosition;
    public RectTransform basicMeleeAttackIcon;
    public RectTransform shieldIcon;
    public RectTransform dashIcon;
    public GameObject basicMeleeAttackTips;
    public GameObject shieldTips;
    public GameObject dashTips;
    public float hoverTipTime = 0.8f;
    //public RectTransform bulletShootingIcon;
    public Button nextButton;

    [HideInInspector] public bool isActivated;

    private int selection = 0;
    private Vector3 originalBasicMeleeAttackPos;
    private Vector3 originalShieldPos;
    private Vector3 originalDashPos;
    //private Vector3 originalBulletShootingPos;

    private Vector3 lastMousePosition;
    private float hoverTimer;

    void Start()
    {
        originalBasicMeleeAttackPos = basicMeleeAttackIcon.position;
        originalShieldPos = shieldIcon.position;
        originalDashPos = dashIcon.position;
        //originalBulletShootingPos = bulletShootingIcon.position;
        nextButton.onClick.AddListener(FinishSetting);
    }

    void Update()
    {
        if (isActivated)
        {
            //ShowTips
            if(Input.mousePosition == lastMousePosition && !Input.GetMouseButton(0))
            {
                if(hoverTimer <= hoverTipTime)
                {
                    hoverTimer += Time.deltaTime;
                }
                else
                {
                    if (selection == 0)
                    {
                        if (IsPointerOverUI(basicMeleeAttackIcon))
                        {
                            basicMeleeAttackTips.SetActive(true);
                            basicMeleeAttackTips.transform.position = basicMeleeAttackIcon.transform.position;
                        }
                        if (IsPointerOverUI(shieldIcon))
                        {
                            shieldTips.SetActive(true);
                            shieldTips.transform.position = shieldIcon.transform.position;
                        }
                        if (IsPointerOverUI(dashIcon))
                        {
                            dashTips.SetActive(true);
                            dashTips.transform.position = dashIcon.transform.position;
                        }
                    }
                }
            }
            else
            {
                if(hoverTimer > hoverTipTime)
                {
                    basicMeleeAttackTips.SetActive(false); 
                    shieldTips.SetActive(false);
                    dashTips.SetActive(false);
                }
                hoverTimer = 0;
            }
            lastMousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if(selection == 0)//selet an ability
                {
                    if (IsPointerOverUI(basicMeleeAttackIcon))
                    {
                        selection = 1;
                    }
                    if (IsPointerOverUI(shieldIcon))
                    {
                        selection = 2;
                    }
                    if (IsPointerOverUI(dashIcon))
                    {
                        selection = 3;
                    }
                    //if (IsPointerOverUI(bulletShootingIcon))
                    //{
                    //    selection = 3;
                    //}
                    for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                    {
                        if (IsPointerOverUI(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().imageTransform))//cancel ability setting
                        {
                            EventInstance buttonFX;
                            buttonFX = RuntimeManager.CreateInstance("event:/FX/UI/UI-Cancel");
                            if (SettingManager.instance != null)
                            {
                                buttonFX.setVolume(SettingManager.instance.overAllVolume);
                            }
                            buttonFX.start();
                            //RuntimeManager.PlayOneShot("event:/FX/UI/UI-Cancel");
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 1)
                            {
                                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
                                basicMeleeAttackIcon.gameObject.SetActive(true);
                                basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
                                break;
                            }
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 2)
                            {
                                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
                                shieldIcon.gameObject.SetActive(true);
                                shieldIcon.position = originalShieldPos;
                                break;
                            }
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 3)
                            {
                                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
                                dashIcon.gameObject.SetActive(true);
                                dashIcon.position = originalDashPos;
                                break;
                            }
                            //if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 3)
                            //{
                            //    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                            //    GameManager.instance.player.GetComponent<PlayerBulletShooting>().ClearAvalibility();
                            //    bulletShootingIcon.gameObject.SetActive(true);
                            //    bulletShootingIcon.position = originalBulletShootingPos;
                            //    break;
                            //}
                        }
                    }
                }
            }
            if(selection != 0)//move the icon with mouse
            {
                if(selection == 1)
                {
                    basicMeleeAttackIcon.transform.position = Input.mousePosition;
                }
                if(selection == 2)
                {
                    shieldIcon.transform.position = Input.mousePosition;
                }
                if (selection == 3)
                {
                    dashIcon.transform.position = Input.mousePosition;
                }
                //if(selection == 3)
                //{
                //    bulletShootingIcon.transform.position = Input.mousePosition;
                //}
            }
            if(Input.GetMouseButtonUp(0) && selection != 0)
            {
                bool isSet = false;
                for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                {
                    if (IsPointerOverUI(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().imageTransform))//move ability to a certain beat
                    {
                        if(selection == 1)
                        {
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
                                selection = 0;
                                return;
                            }
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                            {
                                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                            }
                            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowMeleeAttackIcon();
                            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetSingleAvalibility(i);
                            basicMeleeAttackIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                        if(selection == 2)
                        {
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                shieldIcon.position = originalShieldPos;
                                selection = 0;
                                return;
                            }
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                            {
                                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                            }
                            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon();
                            GameManager.instance.player.GetComponent<PlayerShield>().SetSingleAvalibility(i);
                            shieldIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                        if (selection == 3)
                        {
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                dashIcon.position = originalDashPos;
                                selection = 0;
                                return;
                            }
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                            {
                                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                            }
                            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowDashIcon();
                            GameManager.instance.player.GetComponent<PlayerDash>().SetSingleAvalibility(i);
                            dashIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                        //if (selection == 3)
                        //{
                        //    if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                        //    {
                        //        ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                        //    }
                        //    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowBulletShootingIcon();
                        //    GameManager.instance.player.GetComponent<PlayerBulletShooting>().SetSingleAvalibility(i);
                        //    bulletShootingIcon.gameObject.SetActive(false);
                        //    isSet = true;
                        //    selection = 0;
                        //    break;
                        //}
                    }
                }
                if (!isSet)//not move ability to a certain beat, replace icons' position
                {
                    if (selection == 1)
                    {
                        basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
                        selection = 0;
                    }
                    if (selection == 2)
                    {
                        shieldIcon.position = originalShieldPos;
                        selection = 0;
                    }
                    if (selection == 3)
                    {
                        dashIcon.position = originalDashPos;
                        selection = 0;
                    }
                    //if (selection == 3)
                    //{
                    //    bulletShootingIcon.position = originalBulletShootingPos;
                    //    selection = 0;
                    //}
                }
            }
        }        
    }

    public bool IsPointerOverUI(RectTransform trans)
    {
        if (Input.mousePosition.x <= trans.position.x + (trans.sizeDelta.x / 2) * trans.lossyScale.x
            && Input.mousePosition.x >= trans.position.x - (trans.sizeDelta.x / 2) * trans.lossyScale.x
            && Input.mousePosition.y <= trans.position.y + (trans.sizeDelta.y / 2) * trans.lossyScale.y
            && Input.mousePosition.y >= trans.position.y - (trans.sizeDelta.y / 2) * trans.lossyScale.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Show()
    {
        isActivated = true;
        preBattlePanel.SetActive(true);
        BeatsManager.instance.beatsContainer.transform.position = targetBeatsContainerPosition.position;
        BeatsManager.instance.beatsContainer.transform.localScale = targetBeatsContainerPosition.localScale;
        BeatsManager.instance.SetNormalBGMParameter("GamePhase", 1);
    }

    public void Hide()
    {
        isActivated = false;
        preBattlePanel.SetActive(false);
    }

    public void ClearAbility(int index)
    {
        if(index == 1)
        {
            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
            basicMeleeAttackIcon.gameObject.SetActive(true);
            basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
        }
        else if(index == 2)
        {
            GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
            shieldIcon.gameObject.SetActive(true);
            shieldIcon.position = originalShieldPos;

        }
        else if (index == 3)
        {
            GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
            dashIcon.gameObject.SetActive(true);
            dashIcon.position = originalDashPos;

        }
        //else if(index == 3)
        //{
        //    GameManager.instance.player.GetComponent<PlayerBulletShooting>().ClearAvalibility();
        //    bulletShootingIcon.gameObject.SetActive(true);
        //    bulletShootingIcon.position = originalBulletShootingPos;
        //}
    }

    public void ClearAbilities()
    {
        GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
        GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
        GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
        //GameManager.instance.player.GetComponent<PlayerBulletShooting>().ClearAvalibility();
        basicMeleeAttackIcon.gameObject.SetActive(true);
        shieldIcon.gameObject.SetActive(true);
        dashIcon.gameObject.SetActive(true);
        //bulletShootingIcon.gameObject.SetActive(true);
        basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
        shieldIcon.position = originalShieldPos;
        dashIcon.position = originalDashPos;
        //bulletShootingIcon.position = originalBulletShootingPos;
    }

    public void FinishSetting()
    {
        GridManager.instance.PreActivateCurrentPhase();
        BeatsManager.instance.beatsContainer.transform.position = originalBeatsContainerPosition.position;
        BeatsManager.instance.beatsContainer.transform.localScale = originalBeatsContainerPosition.localScale;
        preBattlePanel.SetActive(false);
    }

    int GetActivatedAbilitiesCount()
    {
        int sum = 0;
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            if(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
            {
                sum++;
            }
        }
        return sum;
    }
}
