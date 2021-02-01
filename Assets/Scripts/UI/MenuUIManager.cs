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
    public GameObject levelButtons;
    public GameObject level1Panel;
    public Toggle isAutoAttackToggle;
    [Header("SettingPanel")]
    public GameObject settingPanel;
    public Slider overAllVolumeSlider;
    public Text overAllVolumeText;
    [Header("LoadingPanel")]
    public GameObject loadingPanel;
    public Slider loadingSlider;
    public Text loadingText;
    public float loadingSpeed;

    private int levelSelectionState;
    private AsyncOperation operation;
    private bool isLoading;

    void Start()
    {
        BackToInitialPanel();
        if(SettingManager.instance != null)
        {
            overAllVolumeSlider.value = SettingManager.instance.overAllVolume;
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        }
    }

    private void Update()
    {
        if (isLoading)
        {
            float targetValue = operation.progress;

            if (operation.progress >= 0.9f)
            {
                targetValue = 1.0f;
            }

            if (targetValue != loadingSlider.value)
            {
                loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
                if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
                {
                    loadingSlider.value = targetValue;
                }
            }

            loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";

            if ((int)(loadingSlider.value * 100) == 100)
            {
                operation.allowSceneActivation = true;
            }
        }
    }

    public void ChangeAutoAttack()
    {
        SettingManager.instance.SwitchAutoAttack(isAutoAttackToggle.isOn);
    }

    public void LoadLevel1Phase(int phaseIndex)
    {
        SettingManager.instance.targetPhase = phaseIndex;
        //SceneManager.LoadScene(1);
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        isLoading = true;
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
        levelButtons.SetActive(true);
        level1Panel.SetActive(false);
        settingPanel.SetActive(false);
        levelSelectionState = 1;
    }

    public void ShowLevel1Panel()
    {
        levelButtons.SetActive(false);
        level1Panel.SetActive(true);
        levelSelectionState = 2;
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
        levelSelectionState = 0;
    }

    public void ShowLoadingPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
        loadingPanel.SetActive(true);
        levelSelectionState = 0;
    }

    public void PlayPanelBack()
    {
        if(levelSelectionState == 1)
        {
            BackToInitialPanel();
        }
        if(levelSelectionState == 2)
        {
            ShowPlayPanel();
        }
    }
}
