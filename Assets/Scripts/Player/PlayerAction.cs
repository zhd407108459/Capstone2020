using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : RhythmObject
{
    [HideInInspector] public List<bool> isActionUsed = new List<bool>();

    void Start()
    {
        isActionUsed.Clear();
        for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
        {
            isActionUsed.Add(false);
        }
    }

    public override void OnBeat(int beatIndex)
    {
        if(beatIndex == 0)
        {
            isActionUsed[BeatsManager.instance.beatsTips.Count - 1] = false;
        }
        else
        {
            isActionUsed[beatIndex - 1] = false;
        }
    }
}
