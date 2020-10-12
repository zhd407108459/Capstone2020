using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseInfo : MonoBehaviour
{
    public bool isBattlePhase;
    public int phaseLength;
    public List<BasicPlatform> basicPlatforms = new List<BasicPlatform>();

    public void Initialize()
    {
        basicPlatforms.Clear();
        BasicPlatform[] bps = GetComponentsInChildren<BasicPlatform>();
        for(int i = 0; i < bps.Length; i++)
        {
            basicPlatforms.Add(bps[i]);
        }
    }
}
