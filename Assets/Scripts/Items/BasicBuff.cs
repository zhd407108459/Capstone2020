﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuff : RhythmObject
{
    public int xPos;
    public int yPos;

    public int existingTime;

    protected int existingTimer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Setup(int x, int y)
    {
        existingTimer = existingTime;
    }
}
