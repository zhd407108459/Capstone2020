using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAbilities : MonoBehaviour
{

    public GameObject preBattlePanel;
    public Transform targetBeatsContainerPosition;
    public RectTransform basicMeleeAttackIcon;
    public RectTransform shieldIcon;
    public Button nextButton;

    [HideInInspector] public bool isActivated;

    private int selection = 0;
    private Vector3 originalBasicMeleeAttackPos;
    private Vector3 originalShieldPos;
    private Vector3 originalBeatsContainerPosition;
    private Vector3 originalBeatsContainerScale;

    void Start()
    {
        originalBasicMeleeAttackPos = basicMeleeAttackIcon.position;
        originalShieldPos = shieldIcon.position;
        originalBeatsContainerPosition = BeatsManager.instance.beatsContainer.transform.position;
        originalBeatsContainerScale = BeatsManager.instance.beatsContainer.transform.localScale;
        nextButton.onClick.AddListener(FinishSetting);
    }

    void Update()
    {
        if (isActivated)
        {
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
                    for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                    {
                        if (IsPointerOverUI(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().imageTransform))//cancel ability setting
                        {
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
                            if (BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                            {
                                ClearAbilities();
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
                            if(BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().AbilityIndex() != 0)
                            {
                                ClearAbilities();
                            }
                            BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().ShowShieldIcon();
                            GameManager.instance.player.GetComponent<PlayerShield>().SetSingleAvalibility(i);
                            shieldIcon.gameObject.SetActive(false);
                            isSet = true;
                            selection = 0;
                            break;
                        }
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
    }

    public void Hide()
    {
        isActivated = false;
        preBattlePanel.SetActive(false);
    }

    public void ClearAbilities()
    {
        GameManager.instance.player.GetComponent<PlayerMeleeAttack>().ClearAvalibility();
        GameManager.instance.player.GetComponent<PlayerShield>().ClearAvalibility();
        basicMeleeAttackIcon.gameObject.SetActive(true);
        shieldIcon.gameObject.SetActive(true);
        basicMeleeAttackIcon.position = originalBasicMeleeAttackPos;
        shieldIcon.position = originalShieldPos;
    }

    public void FinishSetting()
    {
        GridManager.instance.PreActivateCurrentPhase();
        BeatsManager.instance.beatsContainer.transform.position = originalBeatsContainerPosition;
        BeatsManager.instance.beatsContainer.transform.localScale = originalBeatsContainerScale;
        preBattlePanel.SetActive(false);
    }
}
