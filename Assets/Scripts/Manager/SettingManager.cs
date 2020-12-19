using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public bool isAutoAttack;
    public float overAllVolume;

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

}
