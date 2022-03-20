using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Steamworks;
using Steamworks.Data;

public class DialogSet : MonoBehaviour
{
    public List<DialogUnit> dialogUnits = new List<DialogUnit>();

    public bool isFreezeMovement = true;
    public bool isRepeatable;
    public int triggerX;
    public bool isLimitTriggerY;
    public int triggerY;
    public UnityEvent endEvents;

    public int memoryFragID = -1;

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
        if(isRepeatable && memoryFragID != -1)
        {
            CheckMemFragAchievement();
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

    private void CheckMemFragAchievement()
    {
        

        if (SteamClient.IsValid)
        {
            var ach = new Achievement("COLLECT_ALL_MEMORY_FRAGMENTS");
            if (!ach.State)
            {
                int f131 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_3_1");
                int f151 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_5_1");
                int f171 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_7_1");
                int f191 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_9_1");
                int f1131 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_13_1");
                int f1132 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_13_2");
                int f211 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_1_1");
                int f231 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_3_1");
                int f271 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_7_1");
                int f2151 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_15_1");
                int f2152 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_15_2");


                if (memoryFragID == 131 && f131 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_3_1", 1);
                }

                if (memoryFragID == 151 && f151 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_5_1", 1);
                }

                if (memoryFragID == 171 && f171 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_7_1", 1);
                }

                if (memoryFragID == 191 && f191 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_9_1", 1);
                }

                if (memoryFragID == 1131 && f1131 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_13_1", 1);
                }

                if (memoryFragID == 1132 && f1132 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_1_13_2", 1);
                }

                if (memoryFragID == 211 && f211 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_2_1_1", 1);
                }

                if (memoryFragID == 231 && f231 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_2_3_1", 1);
                }

                if (memoryFragID == 271 && f271 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_2_7_1", 1);
                }

                if (memoryFragID == 2151 && f2151 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_2_15_1", 1);
                }

                if (memoryFragID == 2152 && f2152 == 0)
                {
                    SteamUserStats.SetStat("IS_UNLOCK_MEM_2_15_2", 1);
                }

                f131 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_3_1");
                f151 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_5_1");
                f171 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_7_1");
                f191 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_9_1");
                f1131 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_13_1");
                f1132 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_1_13_2");
                f211 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_1_1");
                f231 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_3_1");
                f271 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_7_1");
                f2151 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_15_1");
                f2152 = SteamUserStats.GetStatInt("IS_UNLOCK_MEM_2_15_2");

                int prog = f131 + f151 + f171 + f191 + f1131 + f1132 + f211 + f231 + f271 + f2151 + f2152;

                int tempP = SteamUserStats.GetStatInt("MEM_PROGRESS");
                if(prog > tempP)
                {
                    SteamUserStats.SetStat("MEM_PROGRESS", prog);
                }

                if (prog == 11)
                {
                    ach.Trigger();
                }

            }

        }
    }
}
