﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public bool isAutoAttack;
    public float overAllVolume;

    public int resolutionIndex;
    public KeyCode skill1Keycode;
    public int skill1Index;
    public KeyCode skill2Keycode;
    public int skill2Index;

    public int targetPhase;

    [HideInInspector] public float hearingRange = 18.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SwitchAutoAttack(bool isOn)
    {
        isAutoAttack = isOn;
    }

    public void ChangeOverAllVolume(float volume)
    {
        overAllVolume = volume;
    }

    public void ChangeResolution(int index)
    {
        if(index == 0)
        {
            Screen.SetResolution(1280, 720, false);
        }
        if (index == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }
        if (index == 2)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        if (index == 3)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        resolutionIndex = index;
    }

    public void ChangeSkill1TriggerKey(int index)
    {
        if(index == 0)
        {
            skill1Keycode = KeyCode.B;
        }
        if (index == 1)
        {
            skill1Keycode = KeyCode.C;
        }
        if (index == 2)
        {
            skill1Keycode = KeyCode.G;
        }
        if (index == 3)
        {
            skill1Keycode = KeyCode.H;
        }
        if (index == 4)
        {
            skill1Keycode = KeyCode.I;
        }
        if (index == 5)
        {
            skill1Keycode = KeyCode.J;
        }
        if (index == 6)
        {
            skill1Keycode = KeyCode.K;
        }
        if (index == 7)
        {
            skill1Keycode = KeyCode.L;
        }
        if (index == 8)
        {
            skill1Keycode = KeyCode.M;
        }
        if (index == 9)
        {
            skill1Keycode = KeyCode.N;
        }
        if (index == 10)
        {
            skill1Keycode = KeyCode.O;
        }
        if (index == 11)
        {
            skill1Keycode = KeyCode.P;
        }
        if (index == 12)
        {
            skill1Keycode = KeyCode.R;
        }
        if (index == 13)
        {
            skill1Keycode = KeyCode.T;
        }
        if (index == 14)
        {
            skill1Keycode = KeyCode.U;
        }
        if (index == 15)
        {
            skill1Keycode = KeyCode.V;
        }
        if (index == 16)
        {
            skill1Keycode = KeyCode.X;
        }
        if (index == 17)
        {
            skill1Keycode = KeyCode.Y;
        }
        if (index == 18)
        {
            skill1Keycode = KeyCode.Z;
        }
        if (index == 19)
        {
            skill1Keycode = KeyCode.Mouse0;
        }
        if (index == 20)
        {
            skill1Keycode = KeyCode.Mouse1;
        }
        if (index == 21)
        {
            skill1Keycode = KeyCode.None;
        }
        skill1Index = index;
    }

    public void ChangeSkill2TriggerKey(int index)
    {
        if (index == 0)
        {
            skill2Keycode = KeyCode.B;
        }
        if (index == 1)
        {
            skill2Keycode = KeyCode.C;
        }
        if (index == 2)
        {
            skill2Keycode = KeyCode.G;
        }
        if (index == 3)
        {
            skill2Keycode = KeyCode.H;
        }
        if (index == 4)
        {
            skill2Keycode = KeyCode.I;
        }
        if (index == 5)
        {
            skill2Keycode = KeyCode.J;
        }
        if (index == 6)
        {
            skill2Keycode = KeyCode.K;
        }
        if (index == 7)
        {
            skill2Keycode = KeyCode.L;
        }
        if (index == 8)
        {
            skill2Keycode = KeyCode.M;
        }
        if (index == 9)
        {
            skill2Keycode = KeyCode.N;
        }
        if (index == 10)
        {
            skill2Keycode = KeyCode.O;
        }
        if (index == 11)
        {
            skill2Keycode = KeyCode.P;
        }
        if (index == 12)
        {
            skill2Keycode = KeyCode.R;
        }
        if (index == 13)
        {
            skill2Keycode = KeyCode.T;
        }
        if (index == 14)
        {
            skill2Keycode = KeyCode.U;
        }
        if (index == 15)
        {
            skill2Keycode = KeyCode.V;
        }
        if (index == 16)
        {
            skill2Keycode = KeyCode.X;
        }
        if (index == 17)
        {
            skill2Keycode = KeyCode.Y;
        }
        if (index == 18)
        {
            skill2Keycode = KeyCode.Z;
        }
        if (index == 19)
        {
            skill2Keycode = KeyCode.Mouse0;
        }
        if (index == 20)
        {
            skill2Keycode = KeyCode.Mouse1;
        }
        if (index == 21)
        {
            skill2Keycode = KeyCode.None;
        }
        skill2Index = index;
    }
}
