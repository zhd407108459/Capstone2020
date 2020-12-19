using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("InitialPanel")]
    public GameObject initialPanel;
    [Header("PlayPanel")]
    public GameObject playPanel;
    public Toggle isAutoAttackToggle;
    [Header("SettingPanel")]
    public GameObject settingPanel;
    public Slider overAllVolumeSlider;
    public Text overAllVolumeText;


    void Start()
    {
        BackToInitialPanel();
        if(SettingManager.instance != null)
        {
            overAllVolumeSlider.value = SettingManager.instance.overAllVolume;
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        }
    }
    public void ChangeAutoAttack()
    {
        SettingManager.instance.SwitchAutoAttack(isAutoAttackToggle.isOn);
    }

    public void LoadLevel1Phase(int phaseIndex)
    {
        SettingManager.instance.targetPhase = phaseIndex;
        SceneManager.LoadScene(1);
    }
    public void ChangeOverAllVolume()
    {
        SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
        overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPlayPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void ShowSettingPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void BackToInitialPanel()
    {
        initialPanel.SetActive(true);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
    }
}
