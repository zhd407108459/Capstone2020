﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseInfo : MonoBehaviour
{
    public bool isBattlePhase;
    public int phaseLength;
    public int rageTime;
    public List<BasicPlatform> basicPlatforms = new List<BasicPlatform>();
    public List<BasicEnemy> enemies = new List<BasicEnemy>();
    public List<BasicTrap> traps = new List<BasicTrap>();
    [Header("Generating Buff Settings")]
    public List<GameObject> generateBuffsPrefabs = new List<GameObject>();
    public List<ItemSpawnPosition> generateBuffsPositions = new List<ItemSpawnPosition>();
    public List<float> generateBuffsWeight = new List<float>();
    public int minGenerateBuffsInterval;
    public int maxGenerateBuffsInterval;
    [Header("Generating Debuff Settings")]
    public List<GameObject> generateDebuffsPrefabs = new List<GameObject>();
    public List<ItemSpawnPosition> generateDebuffsPositions = new List<ItemSpawnPosition>();
    public List<float> generateDebuffsWeight = new List<float>();
    public int minGenerateDebuffsInterval;
    public int maxGenerateDebuffsInterval;


    public void Initialize()
    {
        basicPlatforms.Clear();
        BasicPlatform[] bps = GetComponentsInChildren<BasicPlatform>();
        for(int i = 0; i < bps.Length; i++)
        {
            basicPlatforms.Add(bps[i]);
        }

        enemies.Clear();
        BasicEnemy[] bes = GetComponentsInChildren<BasicEnemy>();
        for (int i = 0; i < bes.Length; i++)
        {
            enemies.Add(bes[i]);
            bes[i].gameObject.SetActive(false);
        }

        traps.Clear();
        BasicTrap[] bts = GetComponentsInChildren<BasicTrap>();
        for(int i = 0; i < bts.Length; i++)
        {
            traps.Add(bts[i]);
            bts[i].gameObject.SetActive(false);
        }

    }
}
