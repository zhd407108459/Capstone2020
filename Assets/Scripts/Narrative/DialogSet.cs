using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogSet : MonoBehaviour
{
    public List<DialogUnit> dialogUnits = new List<DialogUnit>();

    public bool isFreezeMovement = true;
    public bool isRepeatable;
    public int triggerX;
    public bool isLimitTriggerY;
    public int triggerY;
    public UnityEvent endEvents;

    [HideInInspector] public int currentIndex;
    [HideInInspector] public bool isStarted;
    [HideInInspector] public bool isPlayed;

    void Start()
    {
        for (int i = 0; i < dialogUnits.Count; i++)
        {
            dialogUnits[i].gameObject.SetActive(false);
        }
        isPlayed = false;
        isStarted = false;
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
        isStarted = true;
        GridManager.instance.StartDialogEvents();
    }

    public void SkipOrNextDialogUnit()
    {
        if (dialogUnits[currentIndex].IsPlayFinished())
        {
            if(currentIndex == dialogUnits.Count - 1)
            {
                if (!isRepeatable)
                {
                    isPlayed = true;
                }
                isStarted = false;
                HideDialogUnits();
                if (isFreezeMovement)
                {
                    GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog = false;
                }
            }
            else
            {
                dialogUnits[currentIndex].StopTpyingFX();
                currentIndex++;
                ShowDialogUnit(currentIndex);
            }
        }
        else
        {
            dialogUnits[currentIndex].ImmediateShow();
            dialogUnits[currentIndex].StopTpyingFX();
        }
    }

    public void EndCurrentDialogSet()
    {
        if (!isRepeatable)
        {
            isPlayed = true;
        }
        isStarted = false;
        HideDialogUnits();
        if (isFreezeMovement)
        {
            GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog = false;
        }
    }

    public void HideDialogUnits()
    {
        for (int i = 0; i < dialogUnits.Count; i++)
        {
            dialogUnits[i].gameObject.SetActive(false);
            dialogUnits[i].StopTpyingFX();
        }
        GridManager.instance.currentDialog = null;
        GridManager.instance.EndDialogEvents();
        GameManager.instance.player.GetComponent<PlayerFaceExpressionController>().Neutral();
        endEvents.Invoke();
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
