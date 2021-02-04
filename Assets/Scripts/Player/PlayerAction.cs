using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : RhythmObject
{
    [HideInInspector] public List<bool> isActionUsed = new List<bool>();

    public GameObject cloudObject;
    public GameObject dizzyTipObject;
    public GameObject damageIncreasingTipObject;

    [HideInInspector] public bool isDizzy;
    [HideInInspector] public float damageIncreasingRatio;

    private int cloudTimer;
    private int dizzyTimer;
    private int damageIncreasingTimer;

    private bool lastAction;


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
            if(!isActionUsed[BeatsManager.instance.beatsTips.Count - 1] && lastAction)
            {
                GridManager.instance.EndCombo();
            }
            lastAction = isActionUsed[BeatsManager.instance.beatsTips.Count - 1];
            isActionUsed[BeatsManager.instance.beatsTips.Count - 1] = false;
        }
        else
        {
            if(!isActionUsed[beatIndex - 1] && lastAction)
            {
                GridManager.instance.EndCombo();
            }
            lastAction = isActionUsed[beatIndex - 1];
            isActionUsed[beatIndex - 1] = false;
        }
        if(cloudTimer > 0)
        {
            cloudTimer--;
            if(cloudTimer == 0)
            {
                cloudObject.SetActive(false);
            }
        }
        if(dizzyTimer > 0)
        {
            dizzyTimer--;
            if(dizzyTimer == 0)
            {
                dizzyTipObject.SetActive(false);
                isDizzy = false;
            }
        }
        if(damageIncreasingRatio > 0)
        {
            damageIncreasingTimer--;
            if(damageIncreasingTimer == 0)
            {
                damageIncreasingTipObject.SetActive(false);
                damageIncreasingRatio = 1.0f;
            }
        }
    }

    public void StartCloud(int time)
    {
        cloudObject.SetActive(true);
        cloudTimer = time;
    }

    public void StartDizzy(int time)
    {
        dizzyTipObject.SetActive(true);
        dizzyTimer = time;
        isDizzy = true;
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
    }
}
