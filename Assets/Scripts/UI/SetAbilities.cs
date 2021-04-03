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
    public RectTransform throwBombIcon;
    public GameObject basicMeleeAttackTips;
    public GameObject shieldTips;
    public GameObject dashTips;
    public GameObject throwBombTips;
    public List<RectTransform> abilityPositions = new List<RectTransform>();
    public GameObject bossPhase1Tip;
    public GameObject bossPhase2Tip;
    public float hoverTipTime = 0.8f;
    //public RectTransform bulletShootingIcon;
    public Button nextButton;

    [HideInInspector] public bool isActivated;

    private int selection = 0;
    public RectTransform originalBasicMeleeAttackPos;
    public RectTransform originalShieldPos;
    public RectTransform originalDashPos;
    public RectTransform originalThrowBombPos;
    //private Vector3 originalBulletShootingPos;

    private Vector3 lastMousePosition;
    private float hoverTimer;

    private string bossFightPreBGMPath = "event:/FX/UI/UI-Heartbeat";
    private EventInstance bossFightPreBGMEvent;

    void Start()
    {
        //originalBasicMeleeAttackPos = basicMeleeAttackIcon.position;
        //originalShieldPos = shieldIcon.position;
        //originalDashPos = dashIcon.position;
        //originalThrowBombPos = throwBombIcon.position;
        //originalBulletShootingPos = bulletShootingIcon.position;
        nextButton.onClick.AddListener(FinishSetting);
        if (GridManager.instance.levelIndex < 2)
        {
            throwBombIcon.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!preBattlePanel.activeSelf)
        {
            return;
        }
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
                        if (IsPointerOverUI(throwBombIcon) && GridManager.instance.levelIndex >= 2)
                        {
                            throwBombTips.SetActive(true);
                            throwBombTips.transform.position = throwBombIcon.transform.position;
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
                    throwBombTips.SetActive(false);
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
                    if (IsPointerOverUI(throwBombIcon) && GridManager.instance.levelIndex >= 2)
                    {
                        selection = 4;
                    }
                    //if (IsPointerOverUI(bulletShootingIcon))
                    //{
                    //    selection = 3;
                    //}
                    for (int i = 0; i < abilityPositions.Count; i++)
                    {
                        if (IsPointerOverUI(abilityPositions[i]))//cancel ability setting
                        {
                            if(abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() != 0)
                            {
                                EventInstance buttonFX;
                                buttonFX = RuntimeManager.CreateInstance("event:/FX/UI/UI-Cancel");
                                if (SettingManager.instance != null)
                                {
                                    buttonFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                                }
                                buttonFX.start();
                            }
                            //RuntimeManager.PlayOneShot("event:/FX/UI/UI-Cancel");
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 1)
                            {
                                abilityPositions[i].GetComponent<AbilityIcon>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
                                basicMeleeAttackIcon.gameObject.SetActive(true);
                                basicMeleeAttackIcon.position = originalBasicMeleeAttackPos.position;
                                break;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 2)
                            {
                                abilityPositions[i].GetComponent<AbilityIcon>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
                                shieldIcon.gameObject.SetActive(true);
                                shieldIcon.position = originalShieldPos.position;
                                break;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 3)
                            {
                                abilityPositions[i].GetComponent<AbilityIcon>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
                                dashIcon.gameObject.SetActive(true);
                                dashIcon.position = originalDashPos.position;
                                break;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 4)
                            {
                                abilityPositions[i].GetComponent<AbilityIcon>().HideIcons();
                                GameManager.instance.player.GetComponent<PlayerThrowBomb>().ClearAvalibility();
                                throwBombIcon.gameObject.SetActive(true);
                                throwBombIcon.position = originalThrowBombPos.position;
                                break;
                            }
                        }
                    }
                    //for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                    //{
                    //    if (IsPointerOverUI(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().imageTransform))//cancel ability setting
                    //    {
                    //        EventInstance buttonFX;
                    //        buttonFX = RuntimeManager.CreateInstance("event:/FX/UI/UI-Cancel");
                    //        if (SettingManager.instance != null)
                    //        {
                    //            buttonFX.setVolume(SettingManager.instance.overAllVolume);
                    //        }
                    //        buttonFX.start();
                    //        //RuntimeManager.PlayOneShot("event:/FX/UI/UI-Cancel");
                    //        if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 1)
                    //        {
                    //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                    //            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
                    //            basicMeleeAttackIcon.gameObject.SetActive(true);
                    //            basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
                    //            break;
                    //        }
                    //        if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 2)
                    //        {
                    //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                    //            GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
                    //            shieldIcon.gameObject.SetActive(true);
                    //            shieldIcon.position = originalShieldPos;
                    //            break;
                    //        }
                    //        if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 3)
                    //        {
                    //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                    //            GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
                    //            dashIcon.gameObject.SetActive(true);
                    //            dashIcon.position = originalDashPos;
                    //            break;
                    //        }
                    //        //if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 3)
                    //        //{
                    //        //    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                    //        //    GameManager.instance.player.GetComponent<PlayerBulletShooting>().ClearAvalibility();
                    //        //    bulletShootingIcon.gameObject.SetActive(true);
                    //        //    bulletShootingIcon.position = originalBulletShootingPos;
                    //        //    break;
                    //        //}
                    //    }
                    //}
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
                if (selection == 4)
                {
                    throwBombIcon.transform.position = Input.mousePosition;
                }
                //if(selection == 3)
                //{
                //    bulletShootingIcon.transform.position = Input.mousePosition;
                //}
            }
            if(Input.GetMouseButtonUp(0) && selection != 0)
            {
                bool isSet = false;
                for (int i = 0; i < abilityPositions.Count; i++)
                {
                    if (IsPointerOverUI(abilityPositions[i]))//move ability to a certain beat
                    {
                        if (selection == 1)
                        {
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                basicMeleeAttackIcon.position = originalBasicMeleeAttackPos.position;
                                selection = 0;
                                return;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() != 0)
                            {
                                ClearAbility(abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex());
                            }
                            abilityPositions[i].GetComponent<AbilityIcon>().ShowMeleeAttackIcon();
                            if (SettingManager.instance != null)
                            {
                                if (i == 0)
                                {
                                    SettingManager.instance.lastSkillIndex1 = 1;
                                }
                                else
                                {
                                    SettingManager.instance.lastSkillIndex2 = 1;
                                }
                            }
                            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetAbilityIcon(abilityPositions[i].GetComponent<AbilityIcon>());
                            basicMeleeAttackIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                        if (selection == 2)
                        {
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                shieldIcon.position = originalShieldPos.position;
                                selection = 0;
                                return;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() != 0)
                            {
                                ClearAbility(abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex());
                            }
                            abilityPositions[i].GetComponent<AbilityIcon>().ShowShieldIcon();
                            if (SettingManager.instance != null)
                            {
                                if (i == 0)
                                {
                                    SettingManager.instance.lastSkillIndex1 = 2;
                                }
                                else
                                {
                                    SettingManager.instance.lastSkillIndex2 = 2;
                                }
                            }
                            GameManager.instance.player.GetComponent<PlayerShield>().SetAbilityIcon(abilityPositions[i].GetComponent<AbilityIcon>());
                            shieldIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                        if (selection == 3)
                        {
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                dashIcon.position = originalDashPos.position;
                                selection = 0;
                                return;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() != 0)
                            {
                                ClearAbility(abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex());
                            }
                            abilityPositions[i].GetComponent<AbilityIcon>().ShowDashIcon();
                            if (SettingManager.instance != null)
                            {
                                if (i == 0)
                                {
                                    SettingManager.instance.lastSkillIndex1 = 3;
                                }
                                else
                                {
                                    SettingManager.instance.lastSkillIndex2 = 3;
                                }
                            }
                            GameManager.instance.player.GetComponent<PlayerDash>().SetAbilityIcon(abilityPositions[i].GetComponent<AbilityIcon>());
                            dashIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }

                        if (selection == 4)
                        {
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                            {
                                throwBombIcon.position = originalThrowBombPos.position;
                                selection = 0;
                                return;
                            }
                            if (abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex() != 0)
                            {
                                ClearAbility(abilityPositions[i].GetComponent<AbilityIcon>().AbilityIndex());
                            }
                            abilityPositions[i].GetComponent<AbilityIcon>().ShowThrowBombIcon();
                            if (SettingManager.instance != null)
                            {
                                if (i == 0)
                                {
                                    SettingManager.instance.lastSkillIndex1 = 4;
                                }
                                else
                                {
                                    SettingManager.instance.lastSkillIndex2 = 4;
                                }
                            }
                            GameManager.instance.player.GetComponent<PlayerThrowBomb>().SetAbilityIcon(abilityPositions[i].GetComponent<AbilityIcon>());
                            throwBombIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
                    }
                }
                //for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                //{
                //    if (IsPointerOverUI(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().imageTransform))//move ability to a certain beat
                //    {
                //        if(selection == 1)
                //        {
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                //            {
                //                basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
                //                selection = 0;
                //                return;
                //            }
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                //            {
                //                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                //            }
                //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowMeleeAttackIcon();
                //            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetSingleAvalibility(i);
                //            basicMeleeAttackIcon.gameObject.SetActive(false);
                //            isSet = true;
                //            selection = 0;
                //            break;
                //        }
                //        if(selection == 2)
                //        {
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                //            {
                //                shieldIcon.position = originalShieldPos;
                //                selection = 0;
                //                return;
                //            }
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                //            {
                //                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                //            }
                //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon();
                //            GameManager.instance.player.GetComponent<PlayerShield>().SetSingleAvalibility(i);
                //            shieldIcon.gameObject.SetActive(false);
                //            isSet = true;
                //            selection = 0;
                //            break;
                //        }
                //        if (selection == 3)
                //        {
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() == 0 && GetActivatedAbilitiesCount() == 2)
                //            {
                //                dashIcon.position = originalDashPos;
                //                selection = 0;
                //                return;
                //            }
                //            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                //            {
                //                ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                //            }
                //            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowDashIcon();
                //            GameManager.instance.player.GetComponent<PlayerDash>().SetSingleAvalibility(i);
                //            dashIcon.gameObject.SetActive(false);
                //            isSet = true;
                //            selection = 0;
                //            break;
                //        }
                //        //if (selection == 3)
                //        //{
                //        //    if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                //        //    {
                //        //        ClearAbility(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex());
                //        //    }
                //        //    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowBulletShootingIcon();
                //        //    GameManager.instance.player.GetComponent<PlayerBulletShooting>().SetSingleAvalibility(i);
                //        //    bulletShootingIcon.gameObject.SetActive(false);
                //        //    isSet = true;
                //        //    selection = 0;
                //        //    break;
                //        //}
                //    }
                //}
                if (!isSet)//not move ability to a certain beat, replace icons' position
                {
                    if (selection == 1)
                    {
                        basicMeleeAttackIcon.position = originalBasicMeleeAttackPos.position;
                        selection = 0;
                    }
                    if (selection == 2)
                    {
                        shieldIcon.position = originalShieldPos.position;
                        selection = 0;
                    }
                    if (selection == 3)
                    {
                        dashIcon.position = originalDashPos.position;
                        selection = 0;
                    }
                    if (selection == 4)
                    {
                        throwBombIcon.position = originalThrowBombPos.position;
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
        if (GridManager.instance.isBossFight)
        {
            bossFightPreBGMEvent = RuntimeManager.CreateInstance(bossFightPreBGMPath);
            if (SettingManager.instance != null)
            {
                bossFightPreBGMEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            bossFightPreBGMEvent.start();
            if (GridManager.instance.boss.canBeAttacked)
            {
                bossPhase1Tip.SetActive(false);
                bossPhase2Tip.SetActive(true);
            }
            else
            {
                bossPhase1Tip.SetActive(true);
                bossPhase2Tip.SetActive(false);
            }
        }
        else
        {
            bossPhase1Tip.SetActive(false);
            bossPhase2Tip.SetActive(false);
        }

        isActivated = true;
        preBattlePanel.SetActive(true);
        BeatsManager.instance.beatsContainer.transform.position = targetBeatsContainerPosition.position;
        BeatsManager.instance.beatsContainer.transform.localScale = targetBeatsContainerPosition.localScale;
        BeatsManager.instance.SetNormalBGMParameter("GamePhase", 1);
        for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            BeatsManager.instance.beatsTips[i].SetActive(false);
        }
        RecoverCoolDown();
        SetSkillKeys();
        if (GridManager.instance.levelIndex < 2)
        {
            throwBombIcon.gameObject.SetActive(false);
        }
        if(SettingManager.instance != null)
        {
            if(SettingManager.instance.lastSkillIndex1 == 1)
            {
                abilityPositions[0].GetComponent<AbilityIcon>().ShowMeleeAttackIcon();
                GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetAbilityIcon(abilityPositions[0].GetComponent<AbilityIcon>());
                basicMeleeAttackIcon.transform.position = abilityPositions[0].transform.position;
                basicMeleeAttackIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex1 == 2)
            {
                abilityPositions[0].GetComponent<AbilityIcon>().ShowShieldIcon();
                GameManager.instance.player.GetComponent<PlayerShield>().SetAbilityIcon(abilityPositions[0].GetComponent<AbilityIcon>());
                shieldIcon.transform.position = abilityPositions[0].transform.position;
                shieldIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex1 == 3)
            {
                abilityPositions[0].GetComponent<AbilityIcon>().ShowDashIcon();
                GameManager.instance.player.GetComponent<PlayerDash>().SetAbilityIcon(abilityPositions[0].GetComponent<AbilityIcon>());
                dashIcon.transform.position = abilityPositions[0].transform.position;
                dashIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex1 == 4)
            {
                abilityPositions[0].GetComponent<AbilityIcon>().ShowThrowBombIcon();
                GameManager.instance.player.GetComponent<PlayerThrowBomb>().SetAbilityIcon(abilityPositions[0].GetComponent<AbilityIcon>());
                throwBombIcon.transform.position = abilityPositions[0].transform.position;
                throwBombIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex2 == 1)
            {
                abilityPositions[1].GetComponent<AbilityIcon>().ShowMeleeAttackIcon();
                GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetAbilityIcon(abilityPositions[1].GetComponent<AbilityIcon>());
                basicMeleeAttackIcon.transform.position = abilityPositions[1].transform.position;
                basicMeleeAttackIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex2 == 2)
            {
                abilityPositions[1].GetComponent<AbilityIcon>().ShowShieldIcon();
                GameManager.instance.player.GetComponent<PlayerShield>().SetAbilityIcon(abilityPositions[1].GetComponent<AbilityIcon>());
                shieldIcon.transform.position = abilityPositions[1].transform.position;
                shieldIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex2 == 3)
            {
                abilityPositions[1].GetComponent<AbilityIcon>().ShowDashIcon();
                GameManager.instance.player.GetComponent<PlayerDash>().SetAbilityIcon(abilityPositions[1].GetComponent<AbilityIcon>());
                dashIcon.transform.position = abilityPositions[1].transform.position;
                dashIcon.gameObject.SetActive(false);
            }
            if (SettingManager.instance.lastSkillIndex2 == 4)
            {
                abilityPositions[1].GetComponent<AbilityIcon>().ShowThrowBombIcon();
                GameManager.instance.player.GetComponent<PlayerThrowBomb>().SetAbilityIcon(abilityPositions[1].GetComponent<AbilityIcon>());
                throwBombIcon.transform.position = abilityPositions[1].transform.position;
                throwBombIcon.gameObject.SetActive(false);
            }
        }
    }

    public void SetSkillKeys()
    {
        if (SettingManager.instance != null)
        {
            abilityPositions[0].GetComponent<AbilityIcon>().SetKeyTip(SettingManager.instance.skill1Keycode);
            abilityPositions[0].GetComponent<AbilityIcon>().triggerKey = SettingManager.instance.skill1Keycode;
            abilityPositions[1].GetComponent<AbilityIcon>().SetKeyTip(SettingManager.instance.skill2Keycode);
            abilityPositions[1].GetComponent<AbilityIcon>().triggerKey = SettingManager.instance.skill2Keycode;
            if (GameManager.instance.player.GetComponent<PlayerMeleeAttack>().abilityIcon != null)
            {
                GameManager.instance.player.GetComponent<PlayerMeleeAttack>().SetAbilityKey();
            }
            if (GameManager.instance.player.GetComponent<PlayerShield>().abilityIcon != null)
            {
                GameManager.instance.player.GetComponent<PlayerShield>().SetAbilityKey();
            }
            if (GameManager.instance.player.GetComponent<PlayerDash>().abilityIcon != null)
            {
                GameManager.instance.player.GetComponent<PlayerDash>().SetAbilityKey();
            }
            if (GameManager.instance.player.GetComponent<PlayerThrowBomb>().abilityIcon != null)
            {
                GameManager.instance.player.GetComponent<PlayerThrowBomb>().SetAbilityKey();
            }

        }
    }

    public void Hide()
    {
        if (GridManager.instance.isBossFight)
        {
            bossFightPreBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        isActivated = false;
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            BeatsManager.instance.beatsTips[i].SetActive(true);
        }
        preBattlePanel.SetActive(false);
    }

    public void ClearAbility(int index)
    {
        if(index == 1)
        {
            GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
            basicMeleeAttackIcon.gameObject.SetActive(true);
            basicMeleeAttackIcon.position = originalBasicMeleeAttackPos.position;
        }
        else if(index == 2)
        {
            GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
            shieldIcon.gameObject.SetActive(true);
            shieldIcon.position = originalShieldPos.position;

        }
        else if (index == 3)
        {
            GameManager.instance.player.GetComponent<PlayerDash>().ClearAvalibility();
            dashIcon.gameObject.SetActive(true);
            dashIcon.position = originalDashPos.position;

        }
        else if (index == 4)
        {
            GameManager.instance.player.GetComponent<PlayerThrowBomb>().ClearAvalibility();
            throwBombIcon.gameObject.SetActive(true);
            throwBombIcon.position = originalThrowBombPos.position;

        }
        if (GridManager.instance.levelIndex < 2)
        {
            throwBombIcon.gameObject.SetActive(false);
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
        GameManager.instance.player.GetComponent<PlayerThrowBomb>().ClearAvalibility();
        //GameManager.instance.player.GetComponent<PlayerBulletShooting>().ClearAvalibility();
        basicMeleeAttackIcon.gameObject.SetActive(true);
        shieldIcon.gameObject.SetActive(true);
        dashIcon.gameObject.SetActive(true);
        throwBombIcon.gameObject.SetActive(true);
        //bulletShootingIcon.gameObject.SetActive(true);
        basicMeleeAttackIcon.position = originalBasicMeleeAttackPos.position;
        shieldIcon.position = originalShieldPos.position;
        dashIcon.position = originalDashPos.position;
        throwBombIcon.position = originalThrowBombPos.position;
        //bulletShootingIcon.position = originalBulletShootingPos;

        if (GridManager.instance.levelIndex < 2)
        {
            throwBombIcon.gameObject.SetActive(false);
        }
    }

    public void RecoverCoolDown()
    {
        for(int i = 0; i < abilityPositions.Count; i++)
        {
            abilityPositions[i].GetComponent<AbilityIcon>().ShowAllCoolDown();
        }
    }

    public void FinishSetting()
    {
        if (GridManager.instance.isBossFight)
        {
            bossFightPreBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        GridManager.instance.PreActivateCurrentPhase();
        BeatsManager.instance.beatsContainer.transform.position = originalBeatsContainerPosition.position;
        BeatsManager.instance.beatsContainer.transform.localScale = originalBeatsContainerPosition.localScale;
        for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            BeatsManager.instance.beatsTips[i].SetActive(true);
        }
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

    public void StopBossPreBGM()
    {
        if (GridManager.instance.isBossFight && bossFightPreBGMEvent.isValid())
        {
            bossFightPreBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

}
