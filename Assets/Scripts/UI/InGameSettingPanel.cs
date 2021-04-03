using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class InGameSettingPanel : MonoBehaviour
{
    public GameObject buttons;
    [Header("SettingPanel")]
    public GameObject settingPanel;
    public Slider overAllVolumeSlider;
    public Text overAllVolumeText;
    public Slider musicVolumeSlider;
    public Text musicVolumeText;
    public Slider soundEffectVolumeSlider;
    public Text soundEffectVolumeText;
    public Dropdown resolutionDropdown;
    public Dropdown skill1Dropdown;
    public Dropdown skill2Dropdown;

    private void Start()
    {
        Back();

        if (SettingManager.instance != null)
        {
            overAllVolumeSlider.value = SettingManager.instance.overAllVolume;
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
            musicVolumeSlider.value = SettingManager.instance.musicVolume;
            musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
            soundEffectVolumeSlider.value = SettingManager.instance.soundEffectVolume;
            soundEffectVolumeText.text = soundEffectVolumeSlider.value.ToString("#0.00");
            resolutionDropdown.value = SettingManager.instance.resolutionIndex;
            skill1Dropdown.value = SettingManager.instance.skill1Index;
            skill2Dropdown.value = SettingManager.instance.skill2Index;
        }
    }

    public void Back()
    {
        settingPanel.SetActive(false);
        buttons.SetActive(true);
    }

    public void Show()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        settingPanel.SetActive(true);
        buttons.SetActive(false);
    }

    public void ChangeOverAllVolume()
    {
        if(SettingManager.instance == null)
        {
            return;
        }
        SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
        overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        if (BeatsManager.instance != null)
        {
            if (BeatsManager.instance.bgmEvent.isValid())
            {
                BeatsManager.instance.bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            }
        }
    }

    public void SetOverAllVolume(float value)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            float v = Mathf.Clamp01(value);
            overAllVolumeSlider.value = v;
            SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
            if (BeatsManager.instance != null)
            {
                if (BeatsManager.instance.bgmEvent.isValid())
                {
                    BeatsManager.instance.bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
                }
            }
        }
    }

    public void ChangeMusicVolume()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        SettingManager.instance.ChangeMusicVolume(musicVolumeSlider.value);
        musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
        if (BeatsManager.instance != null)
        {
            if (BeatsManager.instance.bgmEvent.isValid())
            {
                BeatsManager.instance.bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            }
        }
    }

    public void SetMusicVolume(float value)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            float v = Mathf.Clamp01(value);
            musicVolumeSlider.value = v;
            SettingManager.instance.ChangeMusicVolume(musicVolumeSlider.value);
            musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
            if (BeatsManager.instance != null)
            {
                if (BeatsManager.instance.bgmEvent.isValid())
                {
                    BeatsManager.instance.bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
                }
            }
        }
    }

    public void ChangeSoundEffectVolume()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        SettingManager.instance.ChangeSoundEffectVolume(soundEffectVolumeSlider.value);
        soundEffectVolumeText.text = soundEffectVolumeSlider.value.ToString("#0.00");
    }

    public void SetSoundEffectVolume(float value)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            float v = Mathf.Clamp01(value);
            soundEffectVolumeSlider.value = v;
            SettingManager.instance.ChangeSoundEffectVolume(soundEffectVolumeSlider.value);
            soundEffectVolumeText.text = soundEffectVolumeSlider.value.ToString("#0.00");
        }
    }

    public void SetResolution()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeResolution(resolutionDropdown.value);
        }
    }

    public void SetResolution(int index)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeResolution(index);
        }
    }

    public void SetSkill1TriggerKey()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeSkill1TriggerKey(skill1Dropdown.value);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill2Dropdown.value = 21;
                SettingManager.instance.ChangeSkill2TriggerKey(21);
            }
            GridManager.instance.setAbilities.SetSkillKeys();
        }
    }

    public void SetSkill1TriggerKey(int index)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        int i = Mathf.Clamp(index, 0, 21);
        if (SettingManager.instance != null)
        {
            skill1Dropdown.value = i;
            SettingManager.instance.ChangeSkill1TriggerKey(i);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill2Dropdown.value = 21;
                SettingManager.instance.ChangeSkill2TriggerKey(21);
            }
            GridManager.instance.setAbilities.SetSkillKeys();
        }
    }
    public void SetSkill2TriggerKey()
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeSkill2TriggerKey(skill2Dropdown.value);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill1Dropdown.value = 21;
                SettingManager.instance.ChangeSkill1TriggerKey(21);
            }
            GridManager.instance.setAbilities.SetSkillKeys();
        }
    }

    public void SetSkill2TriggerKey(int index)
    {
        if (SettingManager.instance == null)
        {
            return;
        }
        int i = Mathf.Clamp(index, 0, 21);
        if (SettingManager.instance != null)
        {
            skill2Dropdown.value = i;
            SettingManager.instance.ChangeSkill2TriggerKey(i);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill1Dropdown.value = 21;
                SettingManager.instance.ChangeSkill1TriggerKey(21);
            }
            GridManager.instance.setAbilities.SetSkillKeys();
        }
    }
}
