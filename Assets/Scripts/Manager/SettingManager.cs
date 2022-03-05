using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public string infoPath = "./Data/Settings.setting";

    public bool isAutoAttack;
    public float overAllVolume;
    public float musicVolume;
    public float soundEffectVolume;

    public int resolutionIndex;
    public KeyCode skill1Keycode;
    public int skill1Index;
    public KeyCode skill2Keycode;
    public int skill2Index;

    public int difficulty;

    public int levelProcess;
    public int phaseProcess;

    public int targetPhase;

    public int lastSkillIndex1;
    public int lastSkillIndex2;

    public int language;


    [HideInInspector] public float hearingRange = 18.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadFromPath();
            //GenerateDefaultSetting();
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
        SaveToPath();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        SaveToPath();
    }

    public void ChangeSoundEffectVolume(float volume)
    {
        soundEffectVolume = volume;
        SaveToPath();
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
        SaveToPath();
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
        SaveToPath();
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
        SaveToPath();
    }

    public void ChangeLanguage(int index)
    {
        language = index == 0 ? 0 : 1;
        SaveToPath();
        ApplyLanguageToObjects();
    }

    void ApplyLanguageToObjects()
    {
        foreach (var n in FindObjectsOfType<SimpleTextLocalization>())
        {
            n.ApplyLanguage();
        }
        foreach (var n in FindObjectsOfType<DropdownTextLocalization>())
        {
            n.ApplyLanguage();
        }
        foreach (var n in FindObjectsOfType<SpriteRendererLocalization>())
        {
            n.ApplyLanguage();
        }
        foreach (var n in FindObjectsOfType<ImageLocalization>())
        {
            n.ApplyLanguage();
        }
    }

    public void LoadFromPath()
    {
        SettingInfo temp = null;
        try
        {

            temp = JsonMapper.ToObject<SettingInfo>(File.ReadAllText(infoPath));
        }
        catch
        {

        }

        if(temp != null)
        {
            ChangeOverAllVolume((float)temp.volume);
            ChangeMusicVolume((float)temp.musicVolume);
            ChangeSoundEffectVolume((float)temp.soundEffectVolume);
            ChangeResolution(temp.resolution);
            ChangeSkill1TriggerKey(temp.skill1key);
            ChangeSkill2TriggerKey(temp.skill2key);
            levelProcess = temp.levelProcess > 0 ? temp.levelProcess : 1;
            phaseProcess = temp.phaseProcess > 0 ? temp.phaseProcess : 1;
            language = temp.language == 0 ? 0 : 1;
            if (temp.skill1key == temp.skill2key)
            {
                ChangeSkill1TriggerKey(21);
            }
        }
        else
        {
            GenerateDefaultSetting();
        }
        targetPhase = 0;
        difficulty = 0;
        ApplyLanguageToObjects();
        SaveToPath();
    }

    public void SaveToPath()
    {
        SettingInfo temp = new SettingInfo();
        temp.volume = overAllVolume;
        temp.musicVolume = musicVolume;
        temp.soundEffectVolume = soundEffectVolume;
        temp.resolution = resolutionIndex;
        temp.skill1key = skill1Index;
        temp.skill2key = skill2Index;
        temp.levelProcess = levelProcess;
        temp.phaseProcess = phaseProcess;
        temp.language = language;
        string jsonstr = JsonMapper.ToJson(temp);
        File.WriteAllText(infoPath, jsonstr);
    }

    public void GenerateDefaultSetting()
    {
        SettingInfo temp = new SettingInfo();
        temp.volume = 0.5f;
        temp.musicVolume = 1.0f;
        temp.soundEffectVolume = 1.0f;
        temp.resolution = 0;
        temp.skill1key = 5;
        temp.skill2key = 6;
        temp.levelProcess = 1;
        temp.phaseProcess = 1;
        temp.language = 0;
        string jsonstr = JsonMapper.ToJson(temp);
        File.WriteAllText(infoPath, jsonstr);
    }
    
    public void ClearSkillSelection()
    {
        lastSkillIndex1 = 0;
        lastSkillIndex2 = 0;
    }
}
