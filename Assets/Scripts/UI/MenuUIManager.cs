using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class MenuUIManager : MonoBehaviour
{
    public string BGMEventPath = "event:/MX/Title/MX_Title_Vigorus";
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
    [Header("CreditsPanel")]
    public GameObject creditsPanel;
    public GameObject[] credits;
    public Button creditsPreviousButton;
    public Button creditsNextButton;
    public Text creditsPageIndex;
    [Header("HelpPanel")]
    public GameObject helpPanel;
    public GameObject[] helps;
    public Button helpPreviousButton;
    public Button helpNextButton;
    public Text helpPageIndex;
    [Header("LoadingPanel")]
    public GameObject loadingPanel;
    public Slider loadingSlider;
    public Text loadingText;
    public float loadingSpeed;

    public EventInstance bgmEvent;

    private int levelSelectionState;
    private AsyncOperation operation;
    private bool isLoading;

    private int creditsIndex = 0;
    private int helpIndex = 0;

    void Start()
    {
        BackToInitialPanel();
        creditsNextButton.onClick.AddListener(NextCredits);
        creditsPreviousButton.onClick.AddListener(PreviousCredits);
        helpNextButton.onClick.AddListener(NextHelp);
        helpPreviousButton.onClick.AddListener(PreviousHelp);
        if (SettingManager.instance != null)
        {
            overAllVolumeSlider.value = SettingManager.instance.overAllVolume;
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        }
        bgmEvent = RuntimeManager.CreateInstance(BGMEventPath);
        if (SettingManager.instance != null)
        {
            bgmEvent.setVolume(SettingManager.instance.overAllVolume);
            bgmEvent.start();
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
                bgmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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

    public void LoadLevel1BossPhase()
    {
        SettingManager.instance.targetPhase = 0;
        //SceneManager.LoadScene(1);
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(2);
        operation.allowSceneActivation = false;
        isLoading = true;
    }

    public void ChangeOverAllVolume()
    {
        SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
        overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        bgmEvent.setVolume(SettingManager.instance.overAllVolume);
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
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsIndex = 0;
        creditsPreviousButton.gameObject.SetActive(false);
        creditsNextButton.gameObject.SetActive(true);
        if (credits.Length == 1)
        {
            creditsNextButton.gameObject.SetActive(false);
        }
        for (int i = 1; i < credits.Length; i++)
        {
            credits[i].SetActive(false);
        }
        credits[0].SetActive(true);
        creditsPageIndex.text = (creditsIndex + 1).ToString() + "/" + credits.Length.ToString();
    }

    void PreviousCredits()
    {
        if (creditsIndex > 0)
        {
            creditsIndex--;
            if (creditsIndex == 0)
            {
                creditsPreviousButton.gameObject.SetActive(false);
            }
            if (creditsIndex + 1 == credits.Length - 1)
            {
                creditsNextButton.gameObject.SetActive(true);
            }
            for (int i = 0; i < credits.Length; i++)
            {
                credits[i].SetActive(false);
            }
            credits[creditsIndex].SetActive(true);
            creditsPageIndex.text = (creditsIndex + 1).ToString() + "/" + credits.Length.ToString();
        }
    }

    void NextCredits()
    {
        if (creditsIndex < credits.Length - 1)
        {
            creditsIndex++;
            if (creditsIndex == credits.Length - 1)
            {
                creditsNextButton.gameObject.SetActive(false);
            }
            if (creditsIndex - 1 == 0)
            {
                creditsPreviousButton.gameObject.SetActive(true);
            }
            for (int i = 0; i < credits.Length; i++)
            {
                credits[i].SetActive(false);
            }
            credits[creditsIndex].SetActive(true);
            creditsPageIndex.text = (creditsIndex + 1).ToString() + "/" + credits.Length.ToString();
        }
    }

    public void ShowHelpPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(false);
        helpPanel.SetActive(true);
        helpIndex = 0;
        helpPreviousButton.gameObject.SetActive(false);
        helpNextButton.gameObject.SetActive(true);
        if (helps.Length == 1)
        {
            helpNextButton.gameObject.SetActive(false);
        }
        for (int i = 1; i < helps.Length; i++)
        {
            helps[i].SetActive(false);
        }
        helps[0].SetActive(true);
        helpPageIndex.text = (helpIndex + 1).ToString() + "/" + helps.Length.ToString();
    }

    void PreviousHelp()
    {
        if (helpIndex > 0)
        {
            helpIndex--;
            if (helpIndex == 0)
            {
                helpPreviousButton.gameObject.SetActive(false);
            }
            if (helpIndex + 1 == helps.Length - 1)
            {
                helpNextButton.gameObject.SetActive(true);
            }
            for (int i = 0; i < helps.Length; i++)
            {
                helps[i].SetActive(false);
            }
            helps[helpIndex].SetActive(true);
            helpPageIndex.text = (helpIndex + 1).ToString() + "/" + helps.Length.ToString();
        }
    }

    void NextHelp()
    {
        if (helpIndex < helps.Length - 1)
        {
            helpIndex++;
            if (helpIndex == helps.Length - 1)
            {
                helpNextButton.gameObject.SetActive(false);
            }
            if (helpIndex - 1 == 0)
            {
                helpPreviousButton.gameObject.SetActive(true);
            }
            for (int i = 0; i < helps.Length; i++)
            {
                helps[i].SetActive(false);
            }
            helps[helpIndex].SetActive(true);
            helpPageIndex.text = (helpIndex + 1).ToString() + "/" + helps.Length.ToString();
        }
    }

    public void BackToInitialPanel()
    {
        initialPanel.SetActive(true);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
        levelSelectionState = 0;
    }

    public void ShowLoadingPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(false);
        loadingPanel.SetActive(true);
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
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
