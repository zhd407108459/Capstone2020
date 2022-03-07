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
    public GameObject backgrounds;
    [Header("InitialPanel")]
    public GameObject initialPanel;
    [Header("PlayPanel")]
    public GameObject playPanel;
    public GameObject difficultyButtons;
    public GameObject levelButtons;
    public List<GameObject> levelButtonsList = new List<GameObject>();
    public GameObject level1Panel;
    public List<GameObject> level1ButtonsList = new List<GameObject>();
    public GameObject level2Panel;
    public List<GameObject> level2ButtonsList = new List<GameObject>();
    public GameObject boss3Button;
    public Toggle isAutoAttackToggle;
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
    public Dropdown languageDropdown;
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
            musicVolumeSlider.value = SettingManager.instance.musicVolume;
            musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
            soundEffectVolumeSlider.value = SettingManager.instance.soundEffectVolume;
            soundEffectVolumeText.text = soundEffectVolumeSlider.value.ToString("#0.00");
            resolutionDropdown.value = SettingManager.instance.resolutionIndex;
            skill1Dropdown.value = SettingManager.instance.skill1Index;
            skill2Dropdown.value = SettingManager.instance.skill2Index;
            languageDropdown.value = SettingManager.instance.language;
        }
        bgmEvent = RuntimeManager.CreateInstance(BGMEventPath);
        if (SettingManager.instance != null)
        {
            bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            bgmEvent.start();
        }
        if(TutorialBackToMenu.instance != null)
        {
            if (TutorialBackToMenu.instance.isFinished)
            {
                ShowPlayPanel();
            }
            Destroy(TutorialBackToMenu.instance.gameObject);
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

            if((int)(loadingSlider.value * 100) > 85)
            {
                if (bgmEvent.isValid())
                {
                    bgmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
            }

            if ((int)(loadingSlider.value * 100) == 100)
            {
                if (bgmEvent.isValid())
                {
                    bgmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
                operation.allowSceneActivation = true;
            }
        }
    }

    public void ChangeAutoAttack()
    {
        SettingManager.instance.SwitchAutoAttack(isAutoAttackToggle.isOn);
    }

    public void LoadTutorial()
    {
        SettingManager.instance.targetPhase = 0;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(7);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }

    public void LoadLevel1Phase(int phaseIndex)
    {
        SettingManager.instance.targetPhase = phaseIndex;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }

    public void LoadLevel1BossPhase()
    {
        SettingManager.instance.targetPhase = 0;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(2);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }

    public void LoadLevel2Phase(int phaseIndex)
    {
        SettingManager.instance.targetPhase = phaseIndex;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(3);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }


    public void LoadLevel2BossPhase()
    {
        SettingManager.instance.targetPhase = 0;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(4);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }

    public void LoadBoss3()
    {
        SettingManager.instance.targetPhase = 0;
        ShowLoadingPanel();
        operation = SceneManager.LoadSceneAsync(5);
        operation.allowSceneActivation = false;
        isLoading = true;
        backgrounds.SetActive(false);
    }

    public void ChangeOverAllVolume()
    {
        SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
        overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
        bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
    }

    public void SetOverAllVolume(float value)
    {
        if (SettingManager.instance != null)
        {
            float v = Mathf.Clamp01(value);
            overAllVolumeSlider.value = v;
            SettingManager.instance.ChangeOverAllVolume(overAllVolumeSlider.value);
            overAllVolumeText.text = overAllVolumeSlider.value.ToString("#0.00");
            if (bgmEvent.isValid())
            {
                bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            }
        }
    }

    public void ChangeMusicVolume()
    {
        SettingManager.instance.ChangeMusicVolume(musicVolumeSlider.value);
        musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
        bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
    }

    public void SetMusicVolume(float value)
    {
        if (SettingManager.instance != null)
        {
            float v = Mathf.Clamp01(value);
            musicVolumeSlider.value = v;
            SettingManager.instance.ChangeMusicVolume(musicVolumeSlider.value);
            musicVolumeText.text = musicVolumeSlider.value.ToString("#0.00");
            if (bgmEvent.isValid())
            {
                bgmEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            }
        }
    }

    public void ChangeSoundEffectVolume()
    {
        SettingManager.instance.ChangeSoundEffectVolume(soundEffectVolumeSlider.value);
        soundEffectVolumeText.text = soundEffectVolumeSlider.value.ToString("#0.00");
    }

    public void SetSoundEffectVolume(float value)
    {
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
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeResolution(resolutionDropdown.value);
        }
    }

    public void SetResolution(int index)
    {
        if(SettingManager.instance != null)
        {
            SettingManager.instance.ChangeResolution(index);
        }
    }

    public void SetSkill1TriggerKey()
    {
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeSkill1TriggerKey(skill1Dropdown.value);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill2Dropdown.value = 21;
                SettingManager.instance.ChangeSkill2TriggerKey(21);
            }
        }
    }

    public void SetSkill1TriggerKey(int index)
    {
        int i = Mathf.Clamp(index, 0, 21);
        if (SettingManager.instance != null)
        {
            skill1Dropdown.value = i;
            SettingManager.instance.ChangeSkill1TriggerKey(i);
            if(SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill2Dropdown.value = 21;
                SettingManager.instance.ChangeSkill2TriggerKey(21);
            }
        }
    }
    public void SetSkill2TriggerKey()
    {
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ChangeSkill2TriggerKey(skill2Dropdown.value);
            if (SettingManager.instance.skill1Keycode == SettingManager.instance.skill2Keycode)
            {
                skill1Dropdown.value = 21;
                SettingManager.instance.ChangeSkill1TriggerKey(21);
            }
        }
    }

    public void SetSkill2TriggerKey(int index)
    {
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
        }
    }

    public void SetLanguage()
    {
        if(SettingManager.instance != null)
        {
            SettingManager.instance.ChangeLanguage(languageDropdown.value);
        }
    }

    public void SetLanguage(int index)
    {
        if (SettingManager.instance != null)
        {
            languageDropdown.value = index;
            SettingManager.instance.ChangeLanguage(index);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPlayPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(true);
        difficultyButtons.SetActive(true);
        levelButtons.SetActive(false);
        level1Panel.SetActive(false);
        level2Panel.SetActive(false);
        settingPanel.SetActive(false);
        levelSelectionState = 1;
    }

    public void ShowLevelSelectionPanel()
    {
        difficultyButtons.SetActive(false);
        levelButtons.SetActive(true);
        if (SettingManager.instance != null)
        {
            for(int i = 0; i < levelButtonsList.Count; i++)
            {
                if(i < SettingManager.instance.levelProcess)
                {
                    levelButtonsList[i].SetActive(true);
                }
                else
                {
                    levelButtonsList[i].SetActive(false);
                }
            }
            if(SettingManager.instance.levelProcess < 3)
            {
                boss3Button.SetActive(false);
            }
        }
        level1Panel.SetActive(false);
        level2Panel.SetActive(false);
        levelSelectionState = 2;
    }

    public void ChangeDifficulty(int difficulty)
    {
        if (SettingManager.instance != null)
        {
            SettingManager.instance.difficulty = difficulty;
        }
    }

    public void ShowLevel1Panel()
    {
        difficultyButtons.SetActive(false);
        levelButtons.SetActive(false);
        level1Panel.SetActive(true);
        level2Panel.SetActive(false);
        if (SettingManager.instance != null)
        {
            if(SettingManager.instance.levelProcess > 1)
            {
                for (int i = 0; i < level1ButtonsList.Count; i++)
                {
                    level1ButtonsList[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < level1ButtonsList.Count; i++)
                {
                    if (i < SettingManager.instance.phaseProcess)
                    {
                        level1ButtonsList[i].SetActive(true);
                    }
                    else
                    {
                        level1ButtonsList[i].SetActive(false);
                    }
                }
            }
        }
        levelSelectionState = 3;
    }

    public void ShowLevel2Panel()
    {
        difficultyButtons.SetActive(false);
        levelButtons.SetActive(false);
        level1Panel.SetActive(false);
        level2Panel.SetActive(true);
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.levelProcess > 2)
            {
                for (int i = 0; i < level2ButtonsList.Count; i++)
                {
                    level2ButtonsList[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < level2ButtonsList.Count; i++)
                {
                    if (i < SettingManager.instance.phaseProcess)
                    {
                        level2ButtonsList[i].SetActive(true);
                    }
                    else
                    {
                        level2ButtonsList[i].SetActive(false);
                    }
                }
            }
        }
        levelSelectionState = 3;
    }

    public void ShowSettingPanel()
    {
        initialPanel.SetActive(false);
        playPanel.SetActive(false);
        settingPanel.SetActive(true);
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
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
            languageDropdown.value = SettingManager.instance.language;
        }
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
        if(levelSelectionState == 3)
        {
            ShowLevelSelectionPanel();
        }
    }
}
