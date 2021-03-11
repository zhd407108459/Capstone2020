using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : RhythmObject
{
    [HideInInspector] public List<bool> isActionUsed = new List<bool>();

    public GameObject cloudObject;
    public GameObject dizzyTipObject;
    public GameObject damageIncreasingTipObject;
    public GameObject quickChargeTipObject;
    public GameObject shieldTipObject;
    public GameObject chaosTipObject;
    public GameObject offTuneTipObject;
    public GameObject silenceTipObject;

    [HideInInspector] public bool isDizzy;
    [HideInInspector] public float damageIncreasingRatio;

    private int cloudTimer;
    private int dizzyTimer;
    private int damageIncreasingTimer;
    private int quickChargeTimer;
    private int shieldTimer;
    private int chaosTimer;
    private int offTuneTimer;
    private int silenceTimer;

    [HideInInspector] public int comboBreakTimer = 0;


    void Start()
    {
        isActionUsed.Clear();
        for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            isActionUsed.Add(false);
        }
        cloudTimer = 0;
        dizzyTimer = 0;
        isDizzy = false;
        damageIncreasingTimer = 0;
        damageIncreasingRatio = 1.0f;
    }

    public override void OnBeat(int beatIndex)
    {
        if(beatIndex == 0)
        {
            if(!isActionUsed[BeatsManager.instance.beatsTips.Count - 1])
            {
                comboBreakTimer++;
                if(comboBreakTimer >= 4)
                {
                    GridManager.instance.EndCombo();
                    comboBreakTimer = 0;
                }
            }
            else
            {
                comboBreakTimer = 0;
            }
            isActionUsed[BeatsManager.instance.beatsTips.Count - 1] = false;
        }
        else
        {
            if(!isActionUsed[beatIndex - 1])
            {
                comboBreakTimer++;
                if (comboBreakTimer >= 4)
                {
                    GridManager.instance.EndCombo();
                    comboBreakTimer = 0;
                }
            }
            else
            {
                comboBreakTimer = 0;
            }
            isActionUsed[beatIndex - 1] = false;
        }
        if(cloudTimer > 0)
        {
            cloudTimer--;
            //if(cloudTimer == 0)
            //{
            //    cloudObject.SetActive(false);
            //    GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", false);
            //}
        }
        if(dizzyTimer > 0)
        {
            dizzyTimer--;
            //if(dizzyTimer == 0)
            //{
            //    dizzyTipObject.SetActive(false);
            //    isDizzy = false;
            //    GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", false);
            //}
        }
        if(damageIncreasingRatio > 0)
        {
            damageIncreasingTimer--;
            //if(damageIncreasingTimer == 0)
            //{
            //    damageIncreasingTipObject.SetActive(false);
            //    damageIncreasingRatio = 1.0f;
            //}
        }
        if(quickChargeTimer > 0)
        {
            quickChargeTimer--;
            //if(quickChargeTimer == 0)
            //{
            //    EndQuickCharge();
            //}
        }
        if(shieldTimer > 0)
        {
            shieldTimer--;
            //if(shieldTimer == 0)
            //{
            //    EndShield();
            //}
        }
        if(chaosTimer > 0)
        {
            chaosTimer--;
            //if(chaosTimer == 0)
            //{
            //    EndChaos();
            //}
        }
        if(offTuneTimer > 0)
        {
            offTuneTimer--;
            //if(offTuneTimer == 0)
            //{
            //    EndOffTune();
            //}
        }
        if(silenceTimer > 0)
        {
            silenceTimer--;
            //if(silenceTimer == 0)
            //{
            //    EndSilence();
            //}
        }
    }

    public override void OnSemiBeat(int lastBeatIndex)
    {
        base.OnSemiBeat(lastBeatIndex);
        if (cloudTimer == 0 && cloudObject.activeSelf)
        {
            cloudObject.SetActive(false);
            GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", false);
        }
        if (dizzyTimer == 0 && dizzyTipObject.activeSelf)
        {
            dizzyTipObject.SetActive(false);
            isDizzy = false;
            GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", false);
        }
        if (damageIncreasingTimer == 0 && damageIncreasingTipObject.activeSelf)
        {
            damageIncreasingTipObject.SetActive(false);
            damageIncreasingRatio = 1.0f;
        }
        if (quickChargeTimer == 0 && quickChargeTipObject.activeSelf)
        {
            EndQuickCharge();
        }
        if (shieldTimer == 0 && shieldTipObject.activeSelf)
        {
            EndShield();
        }
        if (chaosTimer == 0 && chaosTipObject.activeSelf)
        {
            EndChaos();
        }
        if (offTuneTimer == 0 && offTuneTipObject.activeSelf)
        {
            EndOffTune();
        }
        if (silenceTimer == 0 && silenceTipObject.activeSelf)
        {
            EndSilence();
        }

    }

    public void StartCloud(int time)
    {
        cloudObject.SetActive(true);
        cloudTimer = time;
        GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", true);
    }

    public void StartDizzy(int time)
    {
        dizzyTipObject.SetActive(true);
        dizzyTimer = time;
        isDizzy = true;
        GridManager.instance.EndCombo();
        GetComponent<PlayerGridMovement>().animator.SetBool("Hurt", true);
    }

    public void StartIncreasingDamage(int time, float ratio)
    {
        damageIncreasingTipObject.SetActive(true);
        damageIncreasingTimer = time;
        damageIncreasingRatio = ratio;
    }

    public void EndIncreasingDamage()
    {

        damageIncreasingTipObject.SetActive(false);
        damageIncreasingTimer = 0;
        damageIncreasingRatio = 1.0f;
    }

    public void StartQuickCharge(int time)
    {
        quickChargeTipObject.SetActive(true);
        quickChargeTimer = time;
    }

    public void EndQuickCharge()
    {
        quickChargeTipObject.SetActive(false);
        quickChargeTimer = 0;
    }

    public void StartShield(int time)
    {
        shieldTipObject.SetActive(true);
        shieldTimer = time;
    }

    public void EndShield()
    {
        shieldTipObject.SetActive(false);
        shieldTimer = 0;
    }

    public void StartChaos(int time)
    {
        chaosTipObject.SetActive(true);
        chaosTimer = time;
    }

    public void EndChaos()
    {
        chaosTipObject.SetActive(false);
        chaosTimer = 0;
    }

    public void StartOffTune(int time)
    {
        if (silenceTimer > 0)
        {
            EndSilence();
        }
        offTuneTipObject.SetActive(true);
        offTuneTimer = time;
        BeatsManager.instance.SetNormalBGMParameter("Debuff", 1);
    }

    public void EndOffTune()
    {
        offTuneTipObject.SetActive(false);
        offTuneTimer = 0;
        BeatsManager.instance.SetNormalBGMParameter("Debuff", 0);
    }

    public void StartSilence(int time)
    {
        if (offTuneTimer > 0)
        {
            EndOffTune();
        }
        silenceTipObject.SetActive(true);
        silenceTimer = time;
        BeatsManager.instance.SetNormalBGMParameter("Debuff", 2);
    }

    public void EndSilence()
    {
        silenceTipObject.SetActive(false);
        silenceTimer = 0;
        BeatsManager.instance.SetNormalBGMParameter("Debuff", 0);
    }

    public void ClearAllBuffs()
    {
        cloudTimer = 0;
        cloudObject.SetActive(false);
        dizzyTimer = 0;
        dizzyTipObject.SetActive(false);
        isDizzy = false;
        damageIncreasingTipObject.SetActive(false);
        damageIncreasingTimer = 0;
        damageIncreasingRatio = 1.0f;
        EndQuickCharge();
        EndShield();
        EndChaos();
        EndOffTune();
        EndSilence();
    }

    public bool IsCloud()
    {
        return cloudTimer > 0;
    }

    public bool IsQuickCharge()
    {
        return quickChargeTimer > 0;
    }

    public bool IsShield()
    {
        return shieldTimer > 0;
    }

    public bool IsChaos()
    {
        return chaosTimer > 0;
    }

    public bool IsOffTune()
    {
        return offTuneTimer > 0;
    }

    public bool IsSilence()
    {
        return shieldTimer > 0;
    }
}
