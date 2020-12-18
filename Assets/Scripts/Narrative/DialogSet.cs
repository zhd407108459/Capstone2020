using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSet : MonoBehaviour
{
    public List<DialogUnit> dialogUnits = new List<DialogUnit>();

    public bool isFreezeMovement = true;
    public int triggerX;
    public bool isLimitTriggerY;
    public int triggerY;

    [HideInInspector] public int currentIndex;
    [HideInInspector] public bool isPlayed;

    void Start()
    {
        for (int i = 0; i < dialogUnits.Count; i++)
        {
            dialogUnits[i].gameObject.SetActive(false);
        }
        isPlayed = false;
    }

    void Update()
    {
        
    }

    public void StartDialogSet()
    {
        currentIndex = 0;
        ShowDialogUnit(currentIndex);
        if (isFreezeMovement)
        {
            GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog = true;
        }
    }

    public void SkipOrNextDialogUnit()
    {
        if (dialogUnits[currentIndex].IsPlayFinished())
        {
            if(currentIndex == dialogUnits.Count - 1)
            {
                HideDialogUnits();
                isPlayed = true;
                if (isFreezeMovement)
                {
                    GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog = false;
                    GridManager.instance.currentDialog = null;
                }
            }
            else
            {
                currentIndex++;
                ShowDialogUnit(currentIndex);
            }
        }
        else
        {
            dialogUnits[currentIndex].ImmediateShow();
        }
    }

    public void HideDialogUnits()
    {
        isPlayed = true;
        for (int i = 0; i < dialogUnits.Count; i++)
        {
            dialogUnits[i].gameObject.SetActive(false);
        }
    }

    public void ShowDialogUnit(int index)
    {
        for (int i = 0; i < dialogUnits.Count; i++)
        {
            dialogUnits[i].gameObject.SetActive(false);
        }
        dialogUnits[index].gameObject.SetActive(true);
        dialogUnits[index].Show();
    }
}
